using AutoMapper;
using AutoMapper.QueryableExtensions;
using CityServicesPortal.Petitions.Application.Interfaces;
using CityServicesPortal.Petitions.Application.ViewModels;
using CityServicesPortal.Petitions.Domain.Commands;
using CityServicesPortal.Petitions.Domain.Core.Bus;
using CityServicesPortal.Petitions.Domain.Interfaces;
using CityServicesPortal.Petitions.Infra.Data.Repository.EventSourcing;
using System;
using System.Collections.Generic;
using System.Text;

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

        public IEnumerable<PetitionViewModel> GetAll()
        {
            return _petitionRepository.GetAll().ProjectTo<PetitionViewModel>();
        }

        public PetitionViewModel GetById(Guid id)
        {
            return _mapper.Map<PetitionViewModel>(_petitionRepository.GetById(id));
        }

        public void Register(PetitionViewModel petitionViewModel)
        {
            var p = petitionViewModel;
            var registerCommand = new RegisterPetitionCommand(p.Name, p.Description, p.Created);
            //var registerCommand = _mapper.Map<RegisterPetitionCommand>(petitionViewModel);
            Bus.SendCommand(registerCommand);
        }

        public void Update(PetitionViewModel petitionViewModel)
        {
            //var updateCommand = _mapper.Map<UpdateCustomerCommand>(customerViewModel);
            //Bus.SendCommand(updateCommand);
        }

        public void Remove(Guid id)
        {
            //var removeCommand = new RemoveCustomerCommand(id);
            //Bus.SendCommand(removeCommand);
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
