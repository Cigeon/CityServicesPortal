using CityServicesPortal.Petitions.Domain.Core.Events;
using System;

namespace CityServicesPortal.Petitions.Domain.Events
{
    public class PetitionVotedEvent : Event
    {
        public PetitionVotedEvent(Guid id, Guid userId, string userFirstName, string userMiddleName, string userLastName)
        {
            Id = id;
            UserId = userId;
            UserFirstName = userFirstName;
            UserMiddleName = userMiddleName;
            UserLastName = userLastName;
        }

        public Guid Id { get; protected set; }

        public Guid UserId { get; protected set; }

        public string UserFirstName { get; protected set; }

        public string UserMiddleName { get; protected set; }

        public string UserLastName { get; protected set; }
    }
}
