using System;

namespace CityServicesPortal.Petitions.Domain.Commands
{
    public class PetitionUpdateCommand : PetitionCommand
    {
        public PetitionUpdateCommand(Guid id, string name, string description, Guid categoryId)
        {
            Id = id;
            Name = name;
            Description = description;
            CategoryId = categoryId;
        }
    }
}
