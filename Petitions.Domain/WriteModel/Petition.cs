using System;
using System.Collections.Generic;

namespace Petitions.Domain.WriteModel
{
    public class Petition
    {
        public Petition(int id, 
                        string name, 
                        string description, 
                        DateTime created, 
                        PetitionsStatus petitionsStatus, 
                        int petitionAreaId, 
                        PetitionArea petitionArea, 
                        int petitionUserId, 
                        PetitionUser petitionUser, 
                        List<PetitionVoter> petitionVoters)
        {
            Id = id;
            Name = name;
            Description = description;
            Created = created;
            PetitionsStatus = petitionsStatus;
            PetitionAreaId = petitionAreaId;
            PetitionArea = petitionArea;
            PetitionUserId = petitionUserId;
            PetitionUser = petitionUser;
            PetitionVoters = petitionVoters;
        }

        public int Id { get; private set; } 
        
        public string Name { get; private set; }

        public string Description { get; private set; } 
        
        public DateTime Created { get; private set; } 

        public PetitionsStatus PetitionsStatus { get; private set; }

        public int PetitionAreaId { get; private set; }

        public PetitionArea PetitionArea { get; private set; }

        public int PetitionUserId { get; private set; }

        public PetitionUser PetitionUser { get; private set; }

        public List<PetitionVoter> PetitionVoters { get; set; }
    }
}
