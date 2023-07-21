using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkshop.Infrastructure.Persistence
{
    public class CarWorkshopDBContext: DbContext  
    {
        public DbSet<CarWorkshop.Domain.Entities.CarWorkshop> CarWorkshops { get; set; }  
        //DbSet prop representation table in database 

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
        //Overriding "OnConfiguring" method with connection string
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=CarWorkshopDb;Trusted_Connection=True;"); 
            //connection string to local database
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Domain.Entities.CarWorkshop>().OwnsOne(c => c.ContactDetails); 
            //ContactDetails is no longer another table,
            //EF know now that ContactDetails is property in table and its representation of CarWorkshop table
        }
    }
}
