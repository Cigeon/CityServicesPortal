using CityServicesPortal.Petitions.Core.WriteModel.Domain;
using CQRSlite.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace CityServicesPortal.Petitions.Core.ReadModel.Events
{
    public class PetitionCreated : Event
    {
        public PetitionCreated(Guid id, int petitionId, string name, string description,
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
        /*
         PetitionCreated
         PetitionUpdated
         PetitionRemoved
         PetitionAreaChanged
         PetitionStatusChanged
         PetitionVoted
         */

        public string Name { get; private set; }

        public string Description { get; private set; }

        public DateTime Created { get; private set; }

        public PetitionsStatus PetitionsStatus { get; private set; }

        public int PetitionAreaId { get; private set; }

        public int PetitionUserId { get; private set; }

        public List<int> PetitionVoters { get; set; }
    }
}
