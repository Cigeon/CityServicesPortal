using CityServicesPortal.Petitions.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CityServicesPortal.Petitions.Application.Interfaces
{
    public interface IUserAppService
    {
        void Register(UserRegisterDto dto);
        IEnumerable<UserDto> GetAll();
        UserDto GetById(Guid id);
        UserDto GetByIdentityId(int id);
        UserDto GetByUserName(string name);
        void Update(UserUpdateDto dto);
        void Remove(Guid id);
    }
}
