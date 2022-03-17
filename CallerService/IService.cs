using CallerService.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace CallerService
{
    [ServiceContract]
    public interface IService
    {
        [OperationContract]
        Task CreateTicket(Ticket ticket);

        [OperationContract]
        Task<IEnumerable<Ticket>> GetTickets(string findString);

    }
}
