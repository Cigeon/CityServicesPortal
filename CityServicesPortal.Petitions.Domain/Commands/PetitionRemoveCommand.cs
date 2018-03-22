using System;
using System.Collections.Generic;
using System.Text;

namespace CityServicesPortal.Petitions.Domain.Commands
{
    public class PetitionRemoveCommand : PetitionCommand
    {
        public PetitionRemoveCommand(Guid id)
        {
            Id = id;
            AggregateId = id;
        }
    }
}
