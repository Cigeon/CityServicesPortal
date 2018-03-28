using CityServicesPortal.Petitions.Domain.Interfaces;
using CityServicesPortal.Petitions.Domain.Models;
using CityServicesPortal.Petitions.Infra.Data.Context;
using System.Linq;

namespace CityServicesPortal.Petitions.Infra.Data.Repository
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(PetitionContext context) : base(context)
        {

        }

        public User GetByIdentityId(int id)
        {
            return DbSet.FirstOrDefault(u => u.IdentityId.Equals(id));
        }

        public User GetByUserName(string name)
        {
            return DbSet.FirstOrDefault(u => u.UserName.Equals(name));
        }
    }
}
