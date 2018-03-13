using CQRSlite.Events;
using System;

namespace CityServicesPortal.Petitions.Core.WriteModel.Domain
{
    public class StoredEvent: IEvent
    {
        public Guid Id { get; set; }
        public Guid AggregateId { get; set; }
        public DateTimeOffset TimeStamp { get; set; }
        public int Version { get; set; }
        public string Data { get; set; }

        // EF Constructor
        public StoredEvent() { }
    }
}
