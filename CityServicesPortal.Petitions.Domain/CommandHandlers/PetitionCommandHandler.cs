using CityServicesPortal.Petitions.Domain.Commands;
using CityServicesPortal.Petitions.Domain.Core.Bus;
using CityServicesPortal.Petitions.Domain.Core.Notifications;
using CityServicesPortal.Petitions.Domain.Events;
using CityServicesPortal.Petitions.Domain.Interfaces;
using CityServicesPortal.Petitions.Domain.Models;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CityServicesPortal.Petitions.Domain.CommandHandlers
{
    public class CustomerCommandHandler : CommandHandler,
        INotificationHandler<RegisterPetitionCommand>
    {
        private readonly IPetitionRepository _customerRepository;
        private readonly IMediatorHandler Bus;

        public CustomerCommandHandler(IPetitionRepository customerRepository,
                                      IUnitOfWork uow,
                                      IMediatorHandler bus,
                                      INotificationHandler<DomainNotification> notifications) : base(uow, bus, notifications)
        {
            _customerRepository = customerRepository;
            Bus = bus;
        }

        public async Task Handle(RegisterPetitionCommand message, CancellationToken cancellationToken)
        {
            //if (!message.IsValid())
            //{
            //    NotifyValidationErrors(message);
            //    return;
            //}

            var petition = new Petition(Guid.NewGuid(), message.Name, message.Description, message.Created);

            //if (_customerRepository.GetByEmail(customer.Email) != null)
            //{
            //    Bus.RaiseEvent(new DomainNotification(message.MessageType, "The customer e-mail has already been taken."));
            //    return;
            //}

            _customerRepository.Add(petition);

            if (Commit())
            {
                await Bus.RaiseEvent(new PetitionRegisteredEvent(petition.Id, petition.Name, petition.Description, petition.Created));
            }
        }        

        public void Dispose()
        {
            _customerRepository.Dispose();
        }
    }
}
