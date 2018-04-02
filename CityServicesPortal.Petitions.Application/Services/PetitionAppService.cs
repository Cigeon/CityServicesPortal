using AutoMapper;
using AutoMapper.QueryableExtensions;
using CityServicesPortal.Petitions.Application.DTOs;
using CityServicesPortal.Petitions.Application.Interfaces;
using CityServicesPortal.Petitions.Domain.Commands;
using CityServicesPortal.Petitions.Domain.Core.Bus;
using CityServicesPortal.Petitions.Domain.Interfaces;
using CityServicesPortal.Petitions.Domain.Models;
using CityServicesPortal.Petitions.Infra.Data.Repository.EventSourcing;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CityServicesPortal.Petitions.Application.Services
{
    public class PetitionAppService : IPetitionAppService
    {
        private readonly IMapper _mapper;
        private readonly IPetitionRepository _petitionRepository;
        private readonly IEventStoreRepository _eventStoreRepository;
        private readonly IMediatorHandler Bus;

        public PetitionAppService(IMapper mapper,
                                  IPetitionRepository petitionRepository,
                                  IMediatorHandler bus,
                                  IEventStoreRepository eventStoreRepository)
        {
            _mapper = mapper;
            _petitionRepository = petitionRepository;
            Bus = bus;
            _eventStoreRepository = eventStoreRepository;
        }

        public IEnumerable<PetitionDto> GetAll()
        {
            return _petitionRepository.GetAll().ProjectTo<PetitionDto>();
        }

        public PetitionDto GetById(Guid id)
        {
            var petition = _petitionRepository.GetById(id);
            return new PetitionDto
            {
                Id = petition.Id,
                Name = petition.Name,
                Description = petition.Description,
                Created = petition.Created,
                Modified = petition.Modified,
                CategoryId = petition.CategoryId,
                Status = petition.Status
            };
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

        public async Task Vote(Guid petitionId, UserDto user)
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
