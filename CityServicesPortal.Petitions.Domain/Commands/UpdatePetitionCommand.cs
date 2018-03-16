using System;

namespace CityServicesPortal.Petitions.Domain.Commands
{
    public class UpdatePetitionCommand : PetitionCommand
    {
        public UpdatePetitionCommand(Guid id, string name, string description, DateTime created)
        {
            Id = id;
            Name = name;
            Description = description;
            Created = created;
        }
    }
}
