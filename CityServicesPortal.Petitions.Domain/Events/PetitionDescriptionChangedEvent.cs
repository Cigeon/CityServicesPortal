using CityServicesPortal.Petitions.Domain.Models;

namespace CityServicesPortal.Petitions.Domain.Events
{
    public class PetitionDescriptionChangedEvent : PetitionEvent
    {
        public PetitionDescriptionChangedEvent(Petition petition) : base(petition)  { }
    }
}
