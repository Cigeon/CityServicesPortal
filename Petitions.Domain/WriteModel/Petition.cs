﻿using System;
using System.Collections.Generic;
using CQRSlite.Domain;
using Petitions.Domain.Events.Petition;

namespace Petitions.Domain.WriteModel
{
    public class Petition : AggregateRoot
    {
        public Petition() {  }

        public Petition(Guid id, int petitionId, string name, string description, 
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

            ApplyChange(new PetitionCreatedEvent(id, petitionId, name, description, created, 
                    petitionsStatus, petitionAreaId, petitionUserId, petitionVoters));
        }

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
