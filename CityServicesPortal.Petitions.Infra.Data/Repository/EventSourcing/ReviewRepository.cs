using CityServicesPortal.Petitions.Domain.Interfaces;
using CityServicesPortal.Petitions.Domain.Models;
using CityServicesPortal.Petitions.Infra.Data.Context;

namespace CityServicesPortal.Petitions.Infra.Data.Repository.EventSourcing
{
    public class ReviewRepository : Repository<Review>, IReviewRepository
    {
        public ReviewRepository(PetitionContext context)
            : base(context)
        { }
    }
}
