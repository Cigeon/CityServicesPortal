using CityServicesPortal.Petitions.Domain.Core.Models;
using System;
using System.Collections.Generic;

namespace CityServicesPortal.Petitions.Domain.Models
{
    public class Petition : Entity
    {             
        public string Name { get; set; }
        public string Description { get; set; }        
        public DateTime Created { get;  set; } 
        public DateTime Modified { get;  set; } 
        public PetitionStatus Status { get; set; }
        public Guid CategoryId { get; set; }
        //public Category Category { get; set; }
        //public Guid PetitionUserId { get; set; }
        //public PetitionUser PetitionUser { get; set; } 

        //public List<PetitionVoter> PetitionVoters { get; set; }        
        //public int VotesCount { get => PetitionVoters.Count; }

        // Empty constructor for EF
        public Petition() { }
    }
}
