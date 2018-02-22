using System;
using System.Collections.Generic;
using System.Text;

namespace CityServicesPortal.Domain.Core
{
    public class PetitionVoter
    {
        public int PetitionId { get; set; }
        public Petition Petition { get; set; }

        public int PetitionUserId { get; set; }
        public PetitionUser PetitionUser { get; set; }
    }
}
