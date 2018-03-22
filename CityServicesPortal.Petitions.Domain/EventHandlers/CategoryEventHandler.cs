using CityServicesPortal.Petitions.Domain.Events;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CityServicesPortal.Petitions.Domain.EventHandlers
{
    public class CategoryEventHandler :
        INotificationHandler<CategoryCreatedEvent>,
        INotificationHandler<CategoryUpdatedEvent>,
        INotificationHandler<CategoryRemovedEvent>,
        INotificationHandler<CategoryNameChangedEvent>,
        INotificationHandler<CategoryDescriptionChangedEvent>
    {  
        public async Task Handle(CategoryCreatedEvent notification, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
        }

        public async Task Handle(CategoryUpdatedEvent notification, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
        }

        public async Task Handle(CategoryRemovedEvent notification, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
        }

        public async Task Handle(CategoryNameChangedEvent notification, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
        }

        public async Task Handle(CategoryDescriptionChangedEvent notification, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
        }
    }
}
