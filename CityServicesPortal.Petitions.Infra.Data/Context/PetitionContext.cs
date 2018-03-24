﻿using CityServicesPortal.Petitions.Domain.Models;
using CityServicesPortal.Petitions.Infra.Data.Mappings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CityServicesPortal.Petitions.Infra.Data.Context
{
    public class PetitionContext : DbContext
    {
        public DbSet<Petition> Petitions { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfiguration(new PetitionMap());

            modelBuilder.Entity<PetitionVoter>()
                .HasKey(t => new { t.PetitionId, t.UserId });

            modelBuilder.Entity<PetitionVoter>()
                .HasOne(pv => pv.Petition)
                .WithMany(p => p.PetitionVoters)
                .OnDelete(DeleteBehavior.Restrict)
                .HasForeignKey(pv => pv.PetitionId);


            modelBuilder.Entity<PetitionVoter>()
                .HasOne(pv => pv.User)
                .WithMany(pu => pu.PetitionVoters)
                .OnDelete(DeleteBehavior.Restrict)
                .HasForeignKey(pv => pv.UserId);

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));
        }
    }
}
