using CityServicesPortal.Petitions.Domain.Core.Events;
using CityServicesPortal.Petitions.Domain.Models;
using System;

namespace CityServicesPortal.Petitions.Domain.Events
{
    public class PetitionStatusChangedEvent : Event
    {
        public PetitionStatusChangedEvent(Guid id, string name, string description, DateTime created, 
            Guid categoryId, PetitionStatus status)
        {
            Id = id;
            AggregateId = id;
            Name = name;
            Description = description;
            Created = created;
            CategoryId = categoryId;
            PetitionStatus = status;
        }

        public Guid Id { get; set; }

        public string Name { get; private set; }

        public string Description { get; private set; }

        public DateTime Created { get; private set; }

        public Guid CategoryId { get; set; }

        public PetitionStatus PetitionStatus { get; set; }
    }
}
