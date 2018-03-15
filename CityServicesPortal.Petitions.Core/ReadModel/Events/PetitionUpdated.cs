using System;
using System.Collections.Generic;
using System.Text;

namespace CityServicesPortal.Petitions.Core.ReadModel.Events
{
    public class PetitionUpdated : Event
    {
        public PetitionUpdated(Guid id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }

        public string Name { get; private set; }

        public string Description { get; private set; }

    }
}
