﻿using CityServicesPortal.Petitions.Domain.Core.Events;
using System;
using System.Collections.Generic;

namespace CityServicesPortal.Petitions.Infra.Data.Repository.EventSourcing
{
    public interface IEventStoreRepository : IDisposable
    {
        void Store(StoredEvent theEvent);
        IList<StoredEvent> All(Guid aggregateId);
    }
}
