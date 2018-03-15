using CQRSlite.Events;
using System;

namespace CityServicesPortal.Petitions.Core.ReadModel.Events
{
    public class StoredEvent: IEvent
    {
        public Guid Id { get; set; }
        public int PetitionId { get; set; }
        public DateTimeOffset TimeStamp { get; set; }
        public int Version { get; set; }
        public string EventType { get; set; }
        public string Data { get; set; }

        // EF Constructor
        public StoredEvent() { }
    }
}
