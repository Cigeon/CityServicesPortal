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
    public class PetitionCommandHandler : CommandHandler,
        INotificationHandler<PetitionRegisterCommand>,
        INotificationHandler<PetitionUpdateCommand>,
        INotificationHandler<PetitionRemoveCommand>,
        INotificationHandler<PetitionChangeNameCommand>,
        INotificationHandler<PetitionChangeDescriptionCommand>,
        INotificationHandler<PetitionChangeStatusCommand>,
        INotificationHandler<PetitionChangeCategoryCommand>

    {
        private readonly IPetitionRepository _petitionRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMediatorHandler Bus;

        public PetitionCommandHandler(IPetitionRepository petitionRepository,
                                      ICategoryRepository categoryRepository,
                                      IUnitOfWork uow,
                                      IMediatorHandler bus,
                                      INotificationHandler<DomainNotification> notifications) : base(uow, bus, notifications)
        {
            _petitionRepository = petitionRepository;
            _categoryRepository = categoryRepository;
            Bus = bus;
        }

        public async Task Handle(PetitionRegisterCommand message, CancellationToken cancellationToken)
        {
            var category = _categoryRepository.GetById(message.CategoryId);
            var petition = new Petition
            {
                Name = message.Name,
                Description = message.Description,
                Created = DateTime.Now,
                Modified = DateTime.Now,
                Category = category
            };

            _petitionRepository.Add(petition);

            if (Commit())
            {
                await Bus.RaiseEvent(new PetitionRegisteredEvent(petition.Id, petition.Name, petition.Description, petition.Created));
            }
        }

        public async Task Handle(PetitionUpdateCommand message, CancellationToken cancellationToken)
        {
            var petition = _petitionRepository.GetById(message.Id);

            if (petition == null)
            {
                await Bus.RaiseEvent(new DomainNotification(message.MessageType, "Can't update petition, because it doesn't exit"));
                return;
            }
            petition.Name = message.Name;
            petition.Description = message.Description;
            petition.Created = message.Created;
            petition.Modified = DateTime.Now;
            petition.CategoryId = message.CategoryId;

            _petitionRepository.Update(petition);

            if (Commit())
            {
                await Bus.RaiseEvent(new PetitionUpdatedEvent(petition.Id, petition.Name, petition.Description, 
                    petition.Created, petition.CategoryId));
            }
        }

        public async Task Handle(PetitionRemoveCommand message, CancellationToken cancellationToken)
        {
            _petitionRepository.Remove(message.Id);

            if (Commit())
            {
                await Bus.RaiseEvent(new PetitionRemovedEvent(message.Id));
            }
        }

        public async Task Handle(PetitionChangeNameCommand message, CancellationToken cancellationToken)
        {
            var petition = _petitionRepository.GetById(message.Id);
            petition.Name = message.Name;
            petition.Modified = DateTime.Now;
            _petitionRepository.Update(petition);

            if (Commit())
            {
                await Bus.RaiseEvent(new PetitionNameChangedEvent(petition));
            }
        }

        public async Task Handle(PetitionChangeDescriptionCommand message, CancellationToken cancellationToken)
        {
            var petition = _petitionRepository.GetById(message.Id);
            petition.Description = message.Description;
            petition.Modified = DateTime.Now;
            _petitionRepository.Update(petition);

            if (Commit())
            {
                await Bus.RaiseEvent(new PetitionDescriptionChangedEvent(petition));
            }
        }

        public async Task Handle(PetitionChangeStatusCommand message, CancellationToken cancellationToken)
        {
            var petition = _petitionRepository.GetById(message.Id);
            petition.Status = message.Status;
            petition.Modified = DateTime.Now;
            _petitionRepository.Update(petition);

            if (Commit())
            {
                await Bus.RaiseEvent(new PetitionStatusChangedEvent(petition));
            }
        }

        public async Task Handle(PetitionChangeCategoryCommand message, CancellationToken cancellationToken)
        {
            var petition = _petitionRepository.GetById(message.Id);
            var category = _categoryRepository.GetById(message.CategoryId);
            petition.Category = category;
            petition.Modified = DateTime.Now;
            _petitionRepository.Update(petition);

            if (Commit())
            {
                await Bus.RaiseEvent(new PetitionCategoryChangedEvent(petition));
            }
        }

        public void Dispose()
        {
            _petitionRepository.Dispose();
        }
    }
}
