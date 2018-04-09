using CityServicesPortal.Petitions.Domain.Core.Models;
using System;

namespace CityServicesPortal.Petitions.Domain.Models
{
    public class Review : Entity
    {
        public string Text { get; set; }
        public DateTime Created { get; set; }
        public Guid PetitionId { get; set; }
        public Petition Petition { get; set; }
        public User User { get; set; }

        public Review()
        { }
    }
}
