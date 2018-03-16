using CityServicesPortal.Petitions.Domain.Core.Events;
using System;

namespace CityServicesPortal.Petitions.Domain.Events
{
    public class PetitionRegisteredEvent : Event
    {
        public PetitionRegisteredEvent(Guid id, string name, string description, DateTime created)
        {
            Id = id;
            AggregateId = id;
            Name = name;
            Description = description;
            Created = created;
        }
        public Guid Id { get; set; }

        public string Name { get; private set; }

        public string Description { get; private set; }

        public DateTime Created { get; private set; }
    }
}
