using CityServicesPortal.Petitions.Domain.Core.Models;
using System;
using System.Collections.Generic;

namespace CityServicesPortal.Petitions.Domain.Models
{
    public class Petition : Entity
    {             
        public string Name { get; private set; }
        public string Description { get; private set; }        
        public DateTime Created { get; private set; } 
        public PetitionsStatus PetitionsStatus { get; private set; }
        //public Guid PetitionAreaId { get; set; }
        //public PetitionArea PetitionArea { get; set; }
        //public Guid PetitionUserId { get; set; }
        //public PetitionUser PetitionUser { get; set; } 

        //public List<PetitionVoter> PetitionVoters { get; set; }        
        //public int VotesCount { get => PetitionVoters.Count; }

        public Petition(Guid id, string name, string description, DateTime created)
        {
            Id = id;
            Name = name;
            Description = description;
            Created = created;
        }

        // Empty constructor for EF
        public Petition() { }
    }
}
