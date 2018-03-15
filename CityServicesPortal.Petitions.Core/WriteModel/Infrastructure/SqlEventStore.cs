using CityServicesPortal.Petitions.Core.ReadModel.Events;
using CityServicesPortal.Petitions.Core.WriteModel.Domain;
using CityServicesPortal.Petitions.Core.WriteModel.Infrastructure.Context;
using CQRSlite.Events;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CityServicesPortal.Petitions.Core.WriteModel.Infrastructure
{
    public class SqlEventStore : IEventStore
    {
        private readonly IEventPublisher _publisher;
        
        public SqlEventStore(IEventPublisher publisher)
        {
            _publisher = publisher;
        }

        public async Task Save(IEnumerable<IEvent> events, CancellationToken cancellationToken = default(CancellationToken))
        {
            foreach (var @event in events)
            {
                var e = (Event)@event;
                var storedEvent = new StoredEvent
                {
                    Id = e.Id,
                    PetitionId = e.PetitionId, 
                    TimeStamp = e.TimeStamp,
                    Version = e.Version,
                    Data = JsonConvert.SerializeObject(e),
                    EventType = e.EventType
                };

                using (var context = new EventStoreContext())
                {
                    context.StoredEvents.Add(storedEvent);
                    context.SaveChanges();
                }

                await _publisher.Publish(@event, cancellationToken);
            }
        }

        public Task<IEnumerable<IEvent>> Get(Guid aggregateId, int fromVersion, CancellationToken cancellationToken = default(CancellationToken))
        {
            using (var context = new EventStoreContext())
            {
                IEnumerable<IEvent> storedEvents = context.StoredEvents
                    .Where(e => e.Id == aggregateId && e.Version > fromVersion)
                    .Cast<IEvent>()
                    .ToList();
                return Task.FromResult(storedEvents ?? new List<IEvent>());
            }
        }
    }
}
