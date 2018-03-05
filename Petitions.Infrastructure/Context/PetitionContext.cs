using Microsoft.EntityFrameworkCore;
using Petitions.Domain.WriteModel;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Petitions.Infrastructure.Context
{
    public class PetitionContext : DbContext
    {
        public DbSet<Petition> Petitions { get; set; }
        public DbSet<PetitionArea> PetitionAreas { get; set; }
        public DbSet<PetitionUser> PetitionUsers { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.ApplyConfiguration(new CustomerMap());

        //    base.OnModelCreating(modelBuilder);
        //}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // get the configuration from the app settings
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            // define the database to use
            optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));
        }
    }
}
