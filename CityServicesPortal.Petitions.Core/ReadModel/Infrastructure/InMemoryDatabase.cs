using CityServicesPortal.Petitions.Core.ReadModel.Dtos;
using System;
using System.Collections.Generic;

namespace CityServicesPortal.Petitions.Core.ReadModel.Infrastructure
{
    public static class InMemoryDatabase
    {
        public static readonly Dictionary<Guid, PetitionDto> Details = new Dictionary<Guid, PetitionDto>();
        public static readonly List<PetitionDto> List = new List<PetitionDto>();
    }
}
