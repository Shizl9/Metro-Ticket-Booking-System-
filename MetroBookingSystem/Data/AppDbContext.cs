using MetroBookingSystem.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroBookingSystem.Data
{
    //create a class AppDbContext that inherits from DbContext
    public class AppDbContext: DbContext
    {
        //
        public DbSet<Train> Trains { get; set; }

        public DbSet<Station> Stations { get; set; }

        public DbSet<Ticket> Tickets { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=MetroBookingSystemDb;Trusted_Connection=True;");
        }
    }
}
