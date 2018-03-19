﻿using AutoMapper;
using AutoMapper.QueryableExtensions;
using CityServicesPortal.Petitions.Application.DTOs;
using CityServicesPortal.Petitions.Application.Interfaces;
using CityServicesPortal.Petitions.Domain.Commands;
using CityServicesPortal.Petitions.Domain.Core.Bus;
using CityServicesPortal.Petitions.Domain.Interfaces;
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
                                  IPetitionRepository customerRepository,
                                  IMediatorHandler bus,
                                  IEventStoreRepository eventStoreRepository)
        {
            _mapper = mapper;
            _petitionRepository = customerRepository;
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
            //return await _mapper.Map<PetitionDto>(_petitionRepository.GetById(id));
        }

        public async Task Register(PetitionRegisterDto p)
        {
            var registerCommand = new RegisterPetitionCommand(p.Name, p.Description, DateTime.Now, p.CategoryId);
            await Bus.SendCommand(registerCommand);
        }

        public async Task Update(PetitionUpdateDto p)
        {
            var updateCommand = new UpdatePetitionCommand(p.Id, p.Name, p.Description, p.CategoryId);
            await Bus.SendCommand(updateCommand);
        }

        public async Task Remove(Guid id)
        {
            var removeCommand = new RemovePetitionCommand(id);
            await Bus.SendCommand(removeCommand);
        }

        public async Task ChangeStatus(PetitionChangeStatusDto p)
        {
            var changeStatusCommand = new PetitionChangeStatusCommand(p.Id, p.Status);
            await Bus.SendCommand(changeStatusCommand);
        }

        public void Vote(Guid petitionId, Guid userId)
        {
            throw new NotImplementedException();
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
