using CityServicesPortal.Petitions.Domain.Core.Commands;
using System;

namespace CityServicesPortal.Petitions.Domain.Commands
{
    public class CategoryChangeDescriptionCommand : Command
    {
        public CategoryChangeDescriptionCommand(Guid id, string description)
        {
            Id = id;
            Description = description;
        }

        public Guid Id { get; protected set; }
        public string Description { get; protected set; }
    }
}
