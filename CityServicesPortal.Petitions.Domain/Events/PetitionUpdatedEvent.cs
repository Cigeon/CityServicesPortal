using CityServicesPortal.Petitions.Domain.Core.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace CityServicesPortal.Petitions.Domain.Events
{
    public class PetitionUpdatedEvent : Event
    {
        public PetitionUpdatedEvent(Guid id, string name, string description, DateTime created, Guid categoryId)
        {
            Id = id;
            AggregateId = id;
            Name = name;
            Description = description;
            Created = created;
            CategoryId = categoryId;
        }

        public Guid Id { get; set; }

        public string Name { get; private set; }

        public string Description { get; private set; }

        public DateTime Created { get; private set; }

        public Guid CategoryId { get; set; }
    }
}
