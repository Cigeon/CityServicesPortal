using System;
using System.Collections.Generic;
using System.Text;

namespace CityServicesPortal.Petitions.Domain.Models
{
    public class PetitionArea
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; }
        public List<Petition> Petitions { get; set; }
    }
}
