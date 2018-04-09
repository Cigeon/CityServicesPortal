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
        public Category Category { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; } 
        public List<PetitionVoter> PetitionVoters { get; set; }
        public Review Review { get; set; }

        public Petition()
        {
            PetitionVoters = new List<PetitionVoter>();
        }
    }
}
