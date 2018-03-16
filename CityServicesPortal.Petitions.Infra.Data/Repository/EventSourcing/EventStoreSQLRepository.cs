using CityServicesPortal.Petitions.Domain.Core.Events;
using CityServicesPortal.Petitions.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CityServicesPortal.Petitions.Infra.Data.Repository.EventSourcing
{
    public class EventStoreSQLRepository : IEventStoreRepository
    {
        private readonly EventStoreSQLContext _context;

        public EventStoreSQLRepository(EventStoreSQLContext context)
        {
            _context = context;
        }

        public IList<StoredEvent> All(Guid aggregateId)
        {
            return _context.StoredEvent.Where(e => e.AggregateId == aggregateId).ToList();
            //return (from e in _context.StoredEvent where e.AggregateId == aggregateId select e).ToList();
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
