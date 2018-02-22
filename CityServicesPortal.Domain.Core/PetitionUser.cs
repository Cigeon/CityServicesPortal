using System;
using System.Collections.Generic;
using System.Text;

namespace CityServicesPortal.Domain.Core
{
    public class PetitionUser
    {
        public int Id { get; set; }
        public int IdentityId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public List<Petition> Petitions { get; set; }

        public List<PetitionVoter> PetitionVoters { get; set; }

        public PetitionUser()
        {
            Petitions = new List<Petition>();
            PetitionVoters = new List<PetitionVoter>();
        }
    }
}
