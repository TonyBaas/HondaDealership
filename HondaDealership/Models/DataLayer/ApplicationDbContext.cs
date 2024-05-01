using HondaDealer.Models;
using HondaDealership.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HondaDealership.Models.DataLayer
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }

        public DbSet<Honda> Hondas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Honda>().HasData(new Honda
            {
                Id = 1,
                VehYear = 1998,
                VehModel = "CIVIC",
                VehBodyType = "HATCHBACK",
                VehPrice = 5000
            }, new Honda
            {
                Id = 2,
                VehYear = 1997,
                VehModel = "CIVIC",
                VehBodyType = "HATCHBACK",
                VehPrice = 5000
            }, new Honda
            {
                Id = 3,
                VehYear = 1998,
                VehModel = "CRV",
                VehBodyType = "SUV",
                VehPrice = 5000
            }, new Honda
            {
                Id = 4,
                VehYear = 1999,
                VehModel = "CRV",
                VehBodyType = "SUV",
                VehPrice = 3000
            }, new Honda
            {
                Id = 5,
                VehYear = 1992,
                VehModel = "CRX",
                VehBodyType = "HATCHBACK",
                VehPrice = 6000
            }
            , new Honda
            {
                Id = 6,
                VehYear = 2005,
                VehModel = "ODYSSEY",
                VehBodyType = "VAN",
                VehPrice = 7000
            }, new Honda
            {
                Id = 7,
                VehYear = 1994,
                VehModel = "PASSPORT",
                VehBodyType = "SUV",
                VehPrice = 1000
            }, new Honda
            {
                Id = 8,
                VehYear = 2024,
                VehModel = "RIDGELINE",
                VehBodyType = "PICKUP",
                VehPrice = 30000
            }

            );
        }
    }
}