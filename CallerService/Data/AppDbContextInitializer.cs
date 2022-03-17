using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallerService.Data
{
    internal class AppDbContextInitializer : CreateDatabaseIfNotExists<AppDbContext>
    {
        protected override void Seed(AppDbContext db)
        {
            List<Caller> callerList = new List<Caller>()
            {
                new Caller () { FullName = "Иванов Иван Иванович", Phone = "+79105551111", DateOfBirth = new DateTime(1990, 1, 15) },
                new Caller () { FullName = "Петров Петр Петрович", Phone = "+79520004444", DateOfBirth = new DateTime(1990, 1, 15), LocationAddress = "Москва" },
                new Caller () { FullName = "Антонов Антон Антонович", Phone = "+79153330000", LocationAddress = "Нижний Новгород" },
            };

            db.Callers.AddRange(callerList);
            db.SaveChanges();
        }
    }
}
