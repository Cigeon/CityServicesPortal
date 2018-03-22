using System;

namespace CityServicesPortal.Petitions.Domain.Commands
{
    public class PetitionRegisterCommand : PetitionCommand
    {
        public PetitionRegisterCommand(string name, string description, DateTime created, Guid categoryId)
        {
            Name = name;
            Description = description;
            Created = created;
            CategoryId = categoryId;
        }
    }
}
