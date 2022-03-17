using System;
using System.Data.Entity;
using System.Linq;

namespace CallerService.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
            : base("name=AppDbContext")
        {
            Database.SetInitializer<AppDbContext>(new AppDbContextInitializer());
        }

        public DbSet<Caller> Callers { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
    }
}