using CityServicesPortal.Petitions.Domain.Core.Events;
using CityServicesPortal.Petitions.Domain.Models;
using System;

namespace CityServicesPortal.Petitions.Domain.Events
{
    public class CategoryUpdatedEvent : Event
    {
        public CategoryUpdatedEvent(Category category)
        {
            Id = category.Id;
            AggregateId = category.Id;
            Name = category.Name;
            Description = category.Description;
        }

        public Guid Id { get; set; }

        public string Name { get; private set; }

        public string Description { get; private set; }
    }
}
