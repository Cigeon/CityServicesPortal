﻿using System;

namespace CityServicesPortal.Petitions.Domain.Core.Events
{
    public class StoredEvent : Event
    {
        //public StoredEvent(Event theEvent, string data, string user)
        public StoredEvent(Event theEvent, string data)
        {
            Id = Guid.NewGuid();
            AggregateId = theEvent.AggregateId;
            MessageType = theEvent.MessageType;
            Data = data;
            //User = user;
        }

        // EF Constructor
        protected StoredEvent() { }

        public Guid Id { get; private set; }

        public string Data { get; private set; }

        //public string User { get; private set; }
    }
}