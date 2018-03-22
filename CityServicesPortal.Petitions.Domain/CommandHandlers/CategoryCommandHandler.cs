using CityServicesPortal.Petitions.Domain.Commands;
using CityServicesPortal.Petitions.Domain.Core.Bus;
using CityServicesPortal.Petitions.Domain.Core.Notifications;
using CityServicesPortal.Petitions.Domain.Events;
using CityServicesPortal.Petitions.Domain.Interfaces;
using CityServicesPortal.Petitions.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CityServicesPortal.Petitions.Domain.CommandHandlers
{
    public class CategoryCommandHandler : CommandHandler,
        INotificationHandler<CategoryCreateCommand>,
        INotificationHandler<CategoryUpdateCommand>,
        INotificationHandler<CategoryRemoveCommand>,
        INotificationHandler<CategoryChangeNameCommand>,
        INotificationHandler<CategoryChangeDescriptionCommand>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMediatorHandler Bus;

        public CategoryCommandHandler(ICategoryRepository categoryRepository,
                                      IUnitOfWork uow,
                                      IMediatorHandler bus,
                                      INotificationHandler<DomainNotification> notifications) : base(uow, bus, notifications)
        {
            _categoryRepository = categoryRepository;
            Bus = bus;
        }

        public async Task Handle(CategoryCreateCommand message, CancellationToken cancellationToken)
        {
            var category = new Category
            {
                Name = message.Name,
                Description = message.Description,
                Created = DateTime.Now,
                Modified = DateTime.Now,
                Petitions = message.Petitions
            };

            _categoryRepository.Add(category);

            if (Commit())
            {
                await Bus.RaiseEvent(new CategoryCreatedEvent(category));
            }
        }

        public async Task Handle(CategoryUpdateCommand message, CancellationToken cancellationToken)
        {
            var category = _categoryRepository.GetById(message.Id);

            if (category == null)
            {
                await Bus.RaiseEvent(new DomainNotification(message.MessageType, "Can't update petition, because it doesn't exit"));
                return;
            }
            category.Name = message.Name;
            category.Description = message.Description;
            category.Modified = DateTime.Now;

            _categoryRepository.Update(category);

            if (Commit())
            {
                await Bus.RaiseEvent(new CategoryUpdatedEvent(category));
            }
        }

        public async Task Handle(CategoryRemoveCommand message, CancellationToken cancellationToken)
        {
            _categoryRepository.Remove(message.Id);

            if (Commit())
            {
                await Bus.RaiseEvent(new CategoryRemovedEvent(message.Id));
            }
        }

        public async Task Handle(CategoryChangeNameCommand message, CancellationToken cancellationToken)
        {
            var category = _categoryRepository.GetById(message.Id);
            category.Name = message.Name;
            category.Modified = DateTime.Now;
            _categoryRepository.Update(category);

            if (Commit())
            {
                await Bus.RaiseEvent(new CategoryNameChangedEvent(category));
            }
        }

        public async Task Handle(CategoryChangeDescriptionCommand message, CancellationToken cancellationToken)
        {
            var category = _categoryRepository.GetById(message.Id);
            category.Description = message.Description;
            category.Modified = DateTime.Now;
            _categoryRepository.Update(category);

            if (Commit())
            {
                await Bus.RaiseEvent(new CategoryDescriptionChangedEvent(category));
            }
        }

        public void Dispose()
        {
            _categoryRepository.Dispose();
        }
    }
}
