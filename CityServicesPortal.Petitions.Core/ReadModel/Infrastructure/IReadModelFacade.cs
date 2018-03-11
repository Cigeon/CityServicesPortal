using CityServicesPortal.Petitions.Core.ReadModel.Dtos;
using System;
using System.Collections.Generic;

namespace CityServicesPortal.Petitions.Core.ReadModel.Infrastructure
{
    public interface IReadModelFacade
    {
        IEnumerable<PetitionDto> GetInventoryItems();
        PetitionDto GetInventoryItemDetails(Guid id);
    }
}
