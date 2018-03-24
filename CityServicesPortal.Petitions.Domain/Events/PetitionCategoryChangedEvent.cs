using CityServicesPortal.Petitions.Domain.Models;

namespace CityServicesPortal.Petitions.Domain.Events
{
    public class PetitionCategoryChangedEvent : PetitionEvent
    {
        public PetitionCategoryChangedEvent(Petition petition) : base(petition) { }
    }
}
