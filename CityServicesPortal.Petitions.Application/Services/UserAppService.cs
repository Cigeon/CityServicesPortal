using CityServicesPortal.Petitions.Application.DTOs;
using CityServicesPortal.Petitions.Application.Interfaces;
using CityServicesPortal.Petitions.Domain.Core.Bus;
using CityServicesPortal.Petitions.Domain.Interfaces;
using CityServicesPortal.Petitions.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CityServicesPortal.Petitions.Application.Services
{
    public class UserAppService : IUserAppService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMediatorHandler Bus;

        public UserAppService(IUserRepository userRepository,
                              IMediatorHandler bus)
        {
            _userRepository = userRepository;
            Bus = bus;
        }

        public IEnumerable<UserDto> GetAll()
        {
            return _userRepository.GetAll()
                .Include(u => u.Petitions)
                .Select(u => new UserDto
                {
                    Id = u.Id,
                    IdentityId = u.IdentityId,
                    UserName = u.UserName,
                    FirstName = u.FirstName,
                    MiddleName = u.MiddleName,
                    LastName = u.LastName,
                    Petitions = u.Petitions.Select(p => new PetitionDto
                    {
                        Id = p.Id,
                        Name = p.Name,
                        Description = p.Description,
                        Created = p.Created,
                        Modified = p.Modified,
                        Status = p.Status
                    }).ToList()
                }).ToList();
        }

        public UserDto GetById(Guid id)
        {
            var user = _userRepository.GetById(id);
            return new UserDto
            {
                Id = user.Id,
                IdentityId = user.IdentityId,
                UserName = user.UserName,
                FirstName = user.FirstName,
                MiddleName = user.MiddleName,
                LastName = user.LastName,
                Petitions = user.Petitions.Select(p => new PetitionDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    Description = p.Description,
                    Created = p.Created,
                    Modified = p.Modified,
                    Status = p.Status
                }).ToList()
            };
        }

        public UserDto GetByIdentityId(int id)
        {
            var user = _userRepository.GetByIdentityId(id);
            return new UserDto
            {
                Id = user.Id,
                IdentityId = user.IdentityId,
                UserName = user.UserName,
                FirstName = user.FirstName,
                MiddleName = user.MiddleName,
                LastName = user.LastName,
                Petitions = user.Petitions.Select(p => new PetitionDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    Description = p.Description,
                    Created = p.Created,
                    Modified = p.Modified,
                    Status = p.Status
                }).ToList()
            };
        }

        public UserDto GetByUserName(string name)
        {
            var user = _userRepository.GetByUserName(name);
            return new UserDto
            {
                Id = user.Id,
                IdentityId = user.IdentityId,
                UserName = user.UserName,
                FirstName = user.FirstName,
                MiddleName = user.MiddleName,
                LastName = user.LastName,
                Petitions = user.Petitions.Select(p => new PetitionDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    Description = p.Description,
                    Created = p.Created,
                    Modified = p.Modified,
                    Status = p.Status
                }).ToList()
            };
        }

        public void Register(UserRegisterDto dto)
        {
            var user = new User
            {
                IdentityId = dto.IdentityId,
                UserName = dto.UserName,
                FirstName = dto.FirstName,
                MiddleName = dto.MiddleName,
                LastName = dto.LastName
            };
            _userRepository.Add(user);
        }

        public void Remove(Guid id)
        {
            _userRepository.Remove(id);
        }

        public void Update(UserUpdateDto dto)
        {
            var user = _userRepository.GetById(dto.Id);
            user.FirstName = dto.FirstName;
            user.MiddleName = dto.MiddleName;
            user.LastName = dto.LastName;
            _userRepository.Update(user);
        }
    }
}
