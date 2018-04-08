using AutoMapper;
using CityServicesPortal.Petitions.Application.DTOs;
using CityServicesPortal.Petitions.Application.Interfaces;
using CityServicesPortal.Petitions.Domain.Commands;
using CityServicesPortal.Petitions.Domain.Core.Bus;
using CityServicesPortal.Petitions.Domain.Interfaces;
using CityServicesPortal.Petitions.Domain.Models;
using CityServicesPortal.Petitions.Infra.Data.Repository.EventSourcing;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityServicesPortal.Petitions.Application.Services
{
    public class PetitionAppService : IPetitionAppService
    {
        private readonly IMapper _mapper;
        private readonly IPetitionRepository _petitionRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IUserRepository _userRepository;
        private readonly IEventStoreRepository _eventStoreRepository;
        private readonly IMediatorHandler Bus;

        public PetitionAppService(IMapper mapper,
                                  IPetitionRepository petitionRepository,
                                  ICategoryRepository categoryRepository,
                                  IUserRepository userRepository,
                                  IMediatorHandler bus,
                                  IEventStoreRepository eventStoreRepository)
        {
            _mapper = mapper;
            Bus = bus;
            _petitionRepository = petitionRepository;
            _categoryRepository = categoryRepository;
            _userRepository = userRepository;            
            _eventStoreRepository = eventStoreRepository;
        }

        public IEnumerable<PetitionDto> GetAll()
        {
            var petitions = _petitionRepository.GetAll()
                .Select(p => new PetitionDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    Description = p.Description,
                    Created = p.Created,
                    Modified = p.Modified,
                    Status = p.Status,
                    Category = new CategoryShortDto
                    {
                        Id = p.Category.Id,
                        Name = p.Category.Name,
                        Description = p.Category.Description
                    },
                    User = new UserShortDto
                    {
                        Id = p.User.Id,
                        UserName = p.User.UserName,
                        FirstName = p.User.FirstName,
                        MiddleName = p.User.MiddleName,
                        LastName = p.User.LastName
                    },
                    Voters = p.PetitionVoters.Select(v => new UserShortDto
                    {
                        Id = v.UserId,
                        UserName = v.User.UserName,
                        FirstName = v.User.FirstName,
                        MiddleName = v.User.MiddleName,
                        LastName = v.User.LastName
                    }).ToList()

                }).ToList();

            return petitions;
        }

        public PetitionDto GetById(Guid id)
        {
            var petition = _petitionRepository.GetAll()
                                .Include(p => p.PetitionVoters)
                                .FirstOrDefault(p => p.Id.Equals(id));
            var category = _categoryRepository.GetById(petition.CategoryId);
            var user = _userRepository.GetById(petition.UserId);
            var petitionDto = new PetitionDto
            {
                Id = petition.Id,
                Name = petition.Name,
                Description = petition.Description,
                Created = petition.Created,
                Modified = petition.Modified,
                Status = petition.Status,
                Category = new CategoryShortDto
                {
                    Id = category.Id,
                    Name = category.Name,
                    Description = category.Description
                },
                User = new UserShortDto
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    FirstName = user.FirstName,
                    MiddleName = user.MiddleName,
                    LastName = user.LastName
                },
                Voters = petition.PetitionVoters.Select(v => new UserShortDto
                {
                    Id = _userRepository.GetById(v.UserId).Id,
                    UserName = _userRepository.GetById(v.UserId).UserName,
                    FirstName = _userRepository.GetById(v.UserId).FirstName,
                    MiddleName = _userRepository.GetById(v.UserId).MiddleName,
                    LastName = _userRepository.GetById(v.UserId).LastName
                }).ToList()
        };
            return petitionDto;
        }

        public async Task Register(PetitionRegisterDto p)
        {
            var registerCommand = new PetitionRegisterCommand(p.Name, p.Description, DateTime.Now, p.CategoryId, p.UserName);
            await Bus.SendCommand(registerCommand);
        }

        public async Task Update(PetitionUpdateDto p)
        {
            var updateCommand = new PetitionUpdateCommand(p.Id, p.Name, p.Description, p.CategoryId);
            await Bus.SendCommand(updateCommand);
        }

        public async Task Remove(Guid id)
        {
            var removeCommand = new PetitionRemoveCommand(id);
            await Bus.SendCommand(removeCommand);
        }

        public async Task ChangeName(Guid id, string name)
        {
            var changeNameCommand = new PetitionChangeNameCommand(id, name);
            await Bus.SendCommand(changeNameCommand);
        }

        public async Task ChangeDescription(Guid id, string description)
        {
            var changeDescriptionCommand = new PetitionChangeDescriptionCommand(id, description);
            await Bus.SendCommand(changeDescriptionCommand);
        }

        public async Task ChangeStatus(Guid id, int status)
        {
            var changeStatusCommand = new PetitionChangeStatusCommand(id, (PetitionStatus)status);
            await Bus.SendCommand(changeStatusCommand);
        }

        public async Task ChangeCategory(Guid id, Guid categoryId)
        {
            var changeCategoryCommand = new PetitionChangeCategoryCommand(id, categoryId);
            await Bus.SendCommand(changeCategoryCommand);
        }

        public async Task Vote(Guid petitionId, UserShortDto user)
        {
            var voteCommand = new PetitionVoteCommand(petitionId, user.Id, user.FirstName, 
                user.MiddleName, user.LastName);
            await Bus.SendCommand(voteCommand);
        }

        //public IList<CustomerHistoryData> GetAllHistory(Guid id)
        //{
        //    return CustomerHistory.ToJavaScriptCustomerHistory(_eventStoreRepository.All(id));
        //}

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }        
    }
}
