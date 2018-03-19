using CityServicesPortal.Petitions.Domain.Core.Models;
using System;
using System.Collections.Generic;

namespace CityServicesPortal.Petitions.Domain.Models
{
    public class Category : Entity
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public DateTime Created { get; private set; }
        public List<Petition> Petitions { get; set; }        

        public Category(string name, string description)
        {
            Name = name;
            Description = description;
            Created = DateTime.Now;
            Petitions = new List<Petition>();
        }

        // Empty constructor for EF
        public Category() { }
    }
}
