using System;

namespace CityServicesPortal.Petitions.Domain.Models
{
    public class PetitionVoter
    {
        public Guid PetitionId { get; set; }
        public Petition Petition { get; set; }

        public Guid UserId { get; set; }
        public User User { get; set; }
    }
}
