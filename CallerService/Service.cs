using CallerService.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.ServiceModel;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CallerService
{
    public class Service : IService
    {
        Regex emailRegex = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", RegexOptions.IgnoreCase);
        Regex phoneRegex = new Regex(@"^\+?\d{11}");

        public async Task CreateTicket(Ticket ticket)
        {
            using (var db = new AppDbContext())
            {
                ticket.Created = DateTime.Now;
                Caller caller = db.Callers.FirstOrDefault(x => x.Id == ticket.CallerId);
                if (caller == null) throw new FaultException($"Caller with Id {ticket.CallerId} was not found.");
                if (String.IsNullOrEmpty(ticket.Message)) throw new FaultException("Missing message text.");
                if (String.IsNullOrEmpty(ticket.Source)) throw new FaultException("Missing source field.");

                if (ticket.Type == TicketType.Email)
                {
                    if (!emailRegex.IsMatch(ticket.Source)) throw new FaultException("Invalid email format.");
                }      
                else
                {
                    if (!phoneRegex.IsMatch(ticket.Source)) throw new FaultException("Invalid phone format.");
                }

                db.Tickets.Add(ticket);
                await db.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Ticket>> GetTickets(string findString)
        {
            using (var db = new AppDbContext())
            {
                Caller caller = await db.Callers.FirstOrDefaultAsync(x => x.FullName == findString || x.Phone == findString);
                return caller != null ? await db.Tickets.Where(x => x.CallerId == caller.Id).ToListAsync() : null;
            }
        }
    }
}
