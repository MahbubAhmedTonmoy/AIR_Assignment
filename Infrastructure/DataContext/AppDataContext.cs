using Core.Entity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirBangladesh.DataContext
{
    public class AppDataContext : IdentityDbContext
    {
        public AppDataContext(DbContextOptions<AppDataContext> options) : base(options)
        {
            //Add-Migration InitialCreate
            //Update-Database
        }
        //public DbSet<PassengerProfile> PassengerProfiles { get; set; }
        //public DbSet<CreditCardDetails> CreditCardDetails { get; set; }
        public DbSet<Flight> Flights { get; set; }
        public DbSet<FlightDetails> FlightDetails { get; set; }
        //public DbSet<TicketInfo> TicketInfos { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<CreditCardDetails>(builder =>
            //{
            //    builder.HasNoKey();
            //});
            //modelBuilder.Entity<FlightDetails>(builder =>
            //{
            //    builder.HasNoKey();
            //});
        }
    }
}
