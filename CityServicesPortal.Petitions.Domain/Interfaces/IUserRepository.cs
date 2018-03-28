using CityServicesPortal.Petitions.Domain.Models;

namespace CityServicesPortal.Petitions.Domain.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        User GetByUserName(string name);
        User GetByIdentityId(int id);
    }
}
