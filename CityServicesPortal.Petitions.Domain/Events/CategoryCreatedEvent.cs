using CityServicesPortal.Petitions.Domain.Core.Events;
using CityServicesPortal.Petitions.Domain.Models;
using System;

namespace CityServicesPortal.Petitions.Domain.Events
{
    public class CategoryCreatedEvent : Event
    {
        public CategoryCreatedEvent(Category category)
        {
            Id = category.Id;
            AggregateId = category.Id;
            Name = category.Name;
            Description = category.Description;
            Created = DateTime.Now;
            Modified = DateTime.Now;
        }

        public Guid Id { get; private set; }

        public string Name { get; private set; }

        public string Description { get; private set; }

        public DateTime Created { get; private set; }

        public DateTime Modified { get; private set; }
    }
}
