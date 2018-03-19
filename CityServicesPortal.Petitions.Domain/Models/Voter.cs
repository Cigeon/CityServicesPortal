using CityServicesPortal.Petitions.Domain.Core.Models;
using System;

namespace CityServicesPortal.Petitions.Domain.Models
{
    public class Voter : Entity
    {
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }

        // Empty constructor for EF
        public Voter() { }
    }
}
