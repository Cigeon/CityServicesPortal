﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Petitions.Domain.Events;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Petitions.Infrastructure.Context
{
    public class EventStoreContext : DbContext
    {
        public DbSet<StoredEvent> StoredEvent { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.ApplyConfiguration(new StoredEventMap());

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