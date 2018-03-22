using CityServicesPortal.Petitions.Domain.Core.Events;
using System;

namespace CityServicesPortal.Petitions.Domain.Events
{
    public class CategoryRemovedEvent : Event
    {
        public CategoryRemovedEvent(Guid id)
        {
            Id = id;
            AggregateId = id;
        }

        public Guid Id { get; set; }
    }
}
