using CityServicesPortal.Petitions.Domain.Core.Events;
using System;

namespace CityServicesPortal.Petitions.Domain.Events
{
    public class PetitionRemovedEvent : Event
    {
        public PetitionRemovedEvent(Guid id)
        {
            Id = id;
            AggregateId = id;
        }

        public Guid Id { get; set; }
    }
}
