using CityServicesPortal.Petitions.Domain.Core.Events;
using CityServicesPortal.Petitions.Domain.Models;
using System;

namespace CityServicesPortal.Petitions.Domain.Events
{
    public class CategoryNameChangedEvent : Event
    {
        public CategoryNameChangedEvent(Category category)
        {
            Id = category.Id;
            AggregateId = category.Id;
            Name = category.Name;
        }

        public Guid Id { get; private set; }

        public string Name { get; private set; }
    }
}
