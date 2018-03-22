using CityServicesPortal.Petitions.Domain.Core.Events;
using CityServicesPortal.Petitions.Domain.Models;
using System;

namespace CityServicesPortal.Petitions.Domain.Events
{
    public class PetitionStatusChangedEvent : PetitionEvent
    {
        public PetitionStatusChangedEvent(Petition petition) : base(petition) { }
    }
}
