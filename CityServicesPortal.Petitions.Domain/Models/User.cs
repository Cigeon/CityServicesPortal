using CityServicesPortal.Petitions.Domain.Core.Models;
using System;
using System.Collections.Generic;

namespace CityServicesPortal.Petitions.Domain.Models
{
    public class User : Entity
    {
        public int IdentityId { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public List<Petition> Petitions { get; set; }
        public List<PetitionVoter> PetitionVoters { get; set; }
        public List<Review> Reviews { get; set; }

        public User()
        {
            Petitions = new List<Petition>();
            PetitionVoters = new List<PetitionVoter>();
            Reviews = new List<Review>();
        }
    }
}
