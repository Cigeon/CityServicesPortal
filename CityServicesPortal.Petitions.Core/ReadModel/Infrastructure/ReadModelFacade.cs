using System;
using System.Collections.Generic;
using CityServicesPortal.Petitions.Core.ReadModel.Dtos;

namespace CityServicesPortal.Petitions.Core.ReadModel.Infrastructure
{
    public class ReadModelFacade : IReadModelFacade
    {
        public PetitionDto GetInventoryItemDetails(Guid id)
        {
            return InMemoryDatabase.Details[id];
        }

        public IEnumerable<PetitionDto> GetInventoryItems()
        {
            return InMemoryDatabase.List;
        }
    }
}
