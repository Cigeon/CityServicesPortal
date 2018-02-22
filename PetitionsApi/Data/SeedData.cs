using CityServicesPortal.Domain.Core;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace PetitionsApi.Data
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetRequiredService<PetitionsContext>();
            context.Database.EnsureCreated();
            if (!context.PetitionAreas.Any())
            {
                context.PetitionAreas.Add(new PetitionArea() { Name = "Police", Description = "Security sphere", Created = DateTime.Now });
                context.SaveChanges();
            }
        }
    }
}
