using CityServicesPortal.Petitions.Core.WriteModel.Domain;
using System;
using System.Collections.Generic;

namespace CityServicesPortal.Petitions.Core.ReadModel.Dtos
{
    public class PetitionDto
    {
        public Guid Id { get; set; }

        public int PetitionId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime Created { get; set; }

        public PetitionsStatus PetitionsStatus { get; set; }

        public int PetitionAreaId { get; set; }

        public int PetitionUserId { get; set; }

        public List<int> PetitionVoters { get; set; }
    }
}
