using Petitions.Domain.Events;
using Petitions.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Petitions.Infrastructure.Repository.EventSourcing
{
    public class EventStoreRepository : IEventStore
    {
        private readonly EventStoreContext _context;

        public EventStoreRepository(EventStoreContext context)
        {
            _context = context;
        }

        public IList<StoredEvent> All(Guid aggregateId)
        {
            return (from e in _context.StoredEvent.Cast<StoredEvent>() where e.AggregateId == aggregateId select e).ToList();
        }

        public void Store(StoredEvent theEvent)
        {
            _context.StoredEvent.Add(theEvent);
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
