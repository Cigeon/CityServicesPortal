using System;
using System.Collections.Generic;
using System.Text;

namespace CityServicesPortal.Petitions.Domain.Commands
{
    public class RemovePetitionCommand : PetitionCommand
    {
        public RemovePetitionCommand(Guid id)
        {
            Id = id;
            AggregateId = id;
        }
    }
}
