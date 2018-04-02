using CityServicesPortal.Petitions.Domain.Core.Commands;
using System;

namespace CityServicesPortal.Petitions.Domain.Commands
{
    public abstract class PetitionCommand : Command
    {
        public Guid Id { get; protected set; }

        public string Name { get; protected set; }

        public string Description { get; protected set; }

        public DateTime Created { get; protected set; }

        public Guid CategoryId { get; set; }

        public string UserName { get; set; }
    }
}
