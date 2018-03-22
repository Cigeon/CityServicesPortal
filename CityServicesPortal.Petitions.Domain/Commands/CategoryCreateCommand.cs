using CityServicesPortal.Petitions.Domain.Core.Commands;
using CityServicesPortal.Petitions.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CityServicesPortal.Petitions.Domain.Commands
{
    public class CategoryCreateCommand : Command
    {
        public CategoryCreateCommand(string name, string description, DateTime created, 
            DateTime modified)
        {
            Name = name;
            Description = description;
            Created = created;
            Modified = modified;
            Petitions = new List<Petition>();
        }

        public string Name { get; protected set; }

        public string Description { get; protected set; }

        public DateTime Created { get; protected set; }

        public DateTime Modified { get; protected set; }

        public List<Petition> Petitions { get; protected set; }
    }
}
