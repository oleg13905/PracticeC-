using CRMApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Runtime.Remoting.Contexts;

namespace CRMApp.Database
{
    public class AppDbContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=crm.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>().HasData(
                new Client
                {
                    Id = 1,
                    Name = "Багдюн Олег",
                    Company = "ООО БелТехСервис",
                    Phone = "+375 29 1234567",
                    Email = "oleg@beltech.by",
                    DealsCount = 12,
                    Status = "Активный"
                },
                new Client
                {
                    Id = 2,
                    Name = "Петров Роман",
                    Company = "ЗАО МинскСтрой",
                    Phone = "+375 33 2345678",
                    Email = "roman@minskstroy.by",
                    DealsCount = 8,
                    Status = "Активный"
                }
            );
        }
    }
}