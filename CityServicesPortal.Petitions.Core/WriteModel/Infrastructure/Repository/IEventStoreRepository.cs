using CityServicesPortal.Petitions.Core.WriteModel.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace CityServicesPortal.Petitions.Core.WriteModel.Infrastructure.Repository
{
    public interface IEventStoreRepository : IDisposable
    {
        void Store(StoredEvent @vent);
        IList<StoredEvent> All(Guid aggregateId);
    }
}
