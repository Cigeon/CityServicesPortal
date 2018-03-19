using System;

namespace CityServicesPortal.Petitions.Domain.Commands
{
    public class UpdatePetitionCommand : PetitionCommand
    {
        public UpdatePetitionCommand(Guid id, string name, string description, Guid categoryId)
        {
            Id = id;
            Name = name;
            Description = description;
            CategoryId = categoryId;
        }
    }
}
