using System;

namespace CityServicesPortal.Petitions.Domain.Commands
{
    public class RegisterPetitionCommand : PetitionCommand
    {
        public RegisterPetitionCommand(string name, string description, DateTime created, Guid categoryId)
        {
            Name = name;
            Description = description;
            Created = created;
            CategoryId = categoryId;
        }
    }
}
