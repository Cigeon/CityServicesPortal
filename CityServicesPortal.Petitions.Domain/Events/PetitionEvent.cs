using CityServicesPortal.Petitions.Domain.Core.Events;
using CityServicesPortal.Petitions.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CityServicesPortal.Petitions.Domain.Events
{
    public class PetitionEvent : Event
    {
        public PetitionEvent(Petition petition)
        {
            Id = petition.Id;
            AggregateId = petition.Id;
            Name = petition.Name;
            Description = petition.Description;
            Created = petition.Created;
            CategoryId = petition.CategoryId;
            PetitionStatus = petition.Status;
        }

        public Guid Id { get; set; }

        public string Name { get; private set; }

        public string Description { get; private set; }

        public DateTime Created { get; private set; }

        public Guid CategoryId { get; set; }

        public PetitionStatus PetitionStatus { get; set; }
    }
}
