using CityServicesPortal.Petitions.Domain.Core.Events;
using CityServicesPortal.Petitions.Domain.Models;
using System;

namespace CityServicesPortal.Petitions.Domain.Events
{
    public class CategoryDescriptionChangedEvent : Event
    {
        public CategoryDescriptionChangedEvent(Category category)
        {
            Id = category.Id;
            AggregateId = category.Id;
            Description = category.Name;
        }

        public Guid Id { get; private set; }

        public string Description { get; private set; }
    }
}
