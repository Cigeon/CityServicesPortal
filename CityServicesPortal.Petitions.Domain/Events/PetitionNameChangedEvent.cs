using CityServicesPortal.Petitions.Domain.Models;

namespace CityServicesPortal.Petitions.Domain.Events
{
    public class PetitionNameChangedEvent : PetitionEvent
    {
        public PetitionNameChangedEvent(Petition petition) : base(petition) { }
    }
}
