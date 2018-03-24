using CityServicesPortal.Petitions.Domain.Core.Events;
using CityServicesPortal.Petitions.Domain.Interfaces;
using CityServicesPortal.Petitions.Infra.Data.Repository.EventSourcing;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CityServicesPortal.Petitions.Infra.Data.EventSourcing
{
    public class SqlEventStore : IEventStore
    {

        private readonly IEventStoreRepository _eventStoreRepository;
        //private readonly IUser _user;

        public SqlEventStore(IEventStoreRepository eventStoreRepository)
        {
            _eventStoreRepository = eventStoreRepository;
            //_user = user;
        }

        public void Save<T>(T @event) where T : Event
        {
            //var serializedData = JsonConvert.SerializeObject(@event);

            var serializedData = JsonConvert.SerializeObject(@event, Formatting.None,
                        new JsonSerializerSettings()
                        {
                            ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                        });

            var storedEvent = new StoredEvent(
                @event,
                serializedData);

            _eventStoreRepository.Store(storedEvent);
        }
    }
}
