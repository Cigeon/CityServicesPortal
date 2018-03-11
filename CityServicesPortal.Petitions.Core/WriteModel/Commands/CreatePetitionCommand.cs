using CityServicesPortal.Petitions.Core.WriteModel.Domain;
using CQRSlite.Commands;
using System;
using System.Collections.Generic;

namespace CityServicesPortal.Petitions.Core.WriteModel.Commands
{
    public class CreatePetitionCommand : ICommand
    {
        public CreatePetitionCommand(Guid id, int petitionId, string name, string description,
            DateTime created, PetitionsStatus petitionsStatus, int petitionAreaId,
            int petitionUserId, List<int> petitionVoters)
        {
            Id = id;
            PetitionId = petitionId;
            Name = name;
            Description = description;
            Created = created;
            PetitionsStatus = petitionsStatus;
            PetitionAreaId = petitionAreaId;
            PetitionUserId = petitionUserId;
            PetitionVoters = petitionVoters;
        }

        public Guid Id { get; set; }

        public int ExpectedVersion { get; set; }

        public int PetitionId { get; private set; }

        public string Name { get; private set; }

        public string Description { get; private set; }

        public DateTime Created { get; private set; }

        public PetitionsStatus PetitionsStatus { get; private set; }

        public int PetitionAreaId { get; private set; }

        public int PetitionUserId { get; private set; }

        public List<int> PetitionVoters { get; set; }
    }
}
