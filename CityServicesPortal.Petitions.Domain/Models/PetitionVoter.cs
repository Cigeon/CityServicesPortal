using System;

namespace CityServicesPortal.Petitions.Domain.Models
{
    public class PetitionVoter
    {
        public Guid PetitionId { get; set; }
        public Petition Petition { get; set; }

        public Guid PetitionUserId { get; set; }
        public PetitionUser PetitionUser { get; set; }
    }
}
