using CityServicesPortal.Petitions.Domain.Interfaces;
using CityServicesPortal.Petitions.Domain.Models;
using CityServicesPortal.Petitions.Infra.Data.Context;

namespace CityServicesPortal.Petitions.Infra.Data.Repository
{
    public class PetitionRepository : Repository<Petition>, IPetitionRepository
    {
        public PetitionRepository(PetitionContext context)
            : base(context)
        {  }
    }
}
