using CityServicesPortal.Petitions.Domain.Core.Commands;
using System;

namespace CityServicesPortal.Petitions.Domain.Commands
{
    public class CategoryRemoveCommand : Command
    {
        public CategoryRemoveCommand(Guid id)
        {
            Id = id;
            AggregateId = id;
        }

        public Guid Id { get; protected set; }
    }
}
