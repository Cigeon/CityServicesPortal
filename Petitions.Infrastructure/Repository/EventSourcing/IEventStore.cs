using Petitions.Domain.Events;
using System;
using System.Collections.Generic;

namespace Petitions.Infrastructure.Repository.EventSourcing
{
    public interface IEventStore : IDisposable 
    {
        void Store(StoredEvent theEvent);
        IList<StoredEvent> All(Guid aggregateId);
    }
}
