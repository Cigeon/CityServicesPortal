using CityServicesPortal.Petitions.Domain.Core.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace CityServicesPortal.Petitions.Domain.Commands
{
    public class CategoryUpdateCommand : Command
    {
        public CategoryUpdateCommand(Guid id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }

        public Guid Id { get; protected set; }

        public string Name { get; protected set; }

        public string Description { get; protected set; }
    }
}
