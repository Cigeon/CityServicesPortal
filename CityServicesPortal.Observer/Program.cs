using CityServicesPortal.Petitions.Domain.Interfaces;
using CityServicesPortal.Petitions.Domain.Models;
using CityServicesPortal.Petitions.Infra.Data.Context;
using CityServicesPortal.Petitions.Infra.Data.Repository;
using CityServicesPortal.Petitions.Infra.Data.Repository.EventSourcing;
using CityServicesPortal.Petitions.Infra.Data.UoW;
using Hangfire;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace CityServicesPortal.Observer
{
    class Program
    {
        static void Main(string[] args)
        {
            GlobalConfiguration.Configuration.UseSqlServerStorage("Server=(localdb)\\mssqllocaldb;Database=ObserverDb;Trusted_Connection=True;MultipleActiveResultSets=true");

            var serviceProvider = new ServiceCollection()
            .AddScoped<PetitionContext>()
            .BuildServiceProvider();


            using (var server = new BackgroundJobServer())
            {
                Console.WriteLine("Hangfire Server started");
                RecurringJob.AddOrUpdate(() => PetitionJob(), Cron.Minutely);
                while (true) { }
            }

        }

        public static void PetitionJob()
        {
            const int votingTime = 5;       // minutes
            const int votersSetpoint = 5;   // voters count for consideration

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Job started at {DateTime.Now}");
            Console.ResetColor();

            using (var context = new PetitionContext())
            {
                var petitions = context.Petitions.ToList();

                foreach (var p in petitions)
                {
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine($"Id: {p.Id}");
                    Console.ResetColor();

                    Console.WriteLine($"Name: {p.Name}");
                    Console.WriteLine($"Status: {p.Status}");
                    Console.WriteLine($"Voted: {p.PetitionVoters.Count}");
                    Console.WriteLine($"Created: {p.Created}");
                    Console.WriteLine($"Modified: {p.Modified}");
                    Console.WriteLine($"Minutes from last modification: {(DateTime.Now - p.Modified).Minutes}");

                    if (p.Status.Equals(PetitionStatus.Voting))
                    {
                        if (p.PetitionVoters.Count >= votersSetpoint)
                        {
                            p.Status = PetitionStatus.Consideration;
                            p.Modified = DateTime.Now;
                            context.Update(p);
                            context.SaveChanges();
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine($">>>>> Status changed to {p.Status}");
                            Console.ResetColor();
                        }
                        else
                        {
                            if ((DateTime.Now - p.Modified).Minutes > votingTime)
                            {
                                p.Status = PetitionStatus.Rejected;
                                p.Modified = DateTime.Now;
                                context.Update(p);
                                context.SaveChanges();
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.WriteLine($"----- Status changed to {p.Status}");
                                Console.ResetColor();
                            }
                        }
                        
                    }
                    Console.WriteLine();
                }

                
            }
        }


    }
}
