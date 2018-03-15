using CQRSlite.Events;
using System;

namespace CityServicesPortal.Petitions.Core.ReadModel.Events
{
    public abstract class Event : IEvent
    {
        public Guid Id { get; set; }

        public int Version { get; set; }

        public DateTimeOffset TimeStamp { get; set; }

        public int PetitionId { get; protected set; }

        public string EventType { get; protected set; }

        public Event()
        {
            EventType = GetType().Name;
        }
    }
}
