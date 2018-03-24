using CityServicesPortal.Petitions.Domain.Core.Commands;
using System;

namespace CityServicesPortal.Petitions.Domain.Commands
{
    public class PetitionChangeCategoryCommand : Command
    {
        public PetitionChangeCategoryCommand(Guid id, Guid categoryId)
        {
            Id = id;
            AggregateId = id;
            CategoryId = categoryId;
        }

        public Guid Id { get; set; }
        public Guid CategoryId { get; set; }

    }
}
