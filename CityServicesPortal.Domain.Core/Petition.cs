using System;
using System.Collections.Generic;

namespace CityServicesPortal.Domain.Core
{
    public class Petition
    {     
        public int Id { get; set; }        
        public string Name { get; set; }
        public string Description { get; set; }        
        public DateTime Created { get; set; } 
        public PetitionsStatus PetitionsStatus { get; set; }

        public int PetitionAreaId { get; set; }
        public PetitionArea PetitionArea { get; set; }

        public int PetitionUserId { get; set; }
        public PetitionUser PetitionUser { get; set; }

        public List<PetitionVoter> PetitionVoters { get; set; }        
        public int VotesCount { get => PetitionVoters.Count; }

        public Petition()
        {
            PetitionVoters = new List<PetitionVoter>();
        }
    }
}
