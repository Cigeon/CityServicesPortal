using CityServicesPortal.Petitions.Domain.Core.Events;
using System;

namespace CityServicesPortal.Petitions.Domain.Events
{
    public class PetitionReviewedEvent : Event
    {
        public PetitionReviewedEvent(Guid id, Guid userId, DateTime created, string text)
        {
            Id = id;
            AggregateId = id;
            UserId = userId;
            Created = created;
            Text = text;
        }
        public Guid Id { get; set; }

        public Guid UserId { get; private set; }

        public DateTime Created { get; private set; }

        public string Text { get; private set; }

    }
}
