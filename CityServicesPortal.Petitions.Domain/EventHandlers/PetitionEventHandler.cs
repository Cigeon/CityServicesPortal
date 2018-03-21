using CityServicesPortal.Petitions.Domain.Events;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CityServicesPortal.Petitions.Domain.EventHandlers
{
    public class PetitionEventHandler :
    INotificationHandler<PetitionRegisteredEvent>,
    INotificationHandler<PetitionUpdatedEvent>,
    INotificationHandler<PetitionRemovedEvent>,
    INotificationHandler<PetitionNameChangedEvent>,
    INotificationHandler<PetitionDescriptionChangedEvent>,
    INotificationHandler<PetitionStatusChangedEvent>
    {
        public async Task Handle(PetitionRegisteredEvent message, CancellationToken cancellationToken)
        {
            // Send some notification e-mail
            await Task.CompletedTask;
        }

        public async Task Handle(PetitionUpdatedEvent message, CancellationToken cancellationToken)
        {
            // Send some notification e-mail
            await Task.CompletedTask;
        }

        public async Task Handle(PetitionRemovedEvent message, CancellationToken cancellationToken)
        {
            // Send some notification e-mail
            await Task.CompletedTask;
        }

        public async Task Handle(PetitionNameChangedEvent message, CancellationToken cancellationToken)
        {
            // Send some notification e-mail
            await Task.CompletedTask;
        }

        public async Task Handle(PetitionDescriptionChangedEvent message, CancellationToken cancellationToken)
        {
            // Send some notification e-mail
            await Task.CompletedTask;
        }

        public async Task Handle(PetitionStatusChangedEvent message, CancellationToken cancellationToken)
        {
            // Send some notification e-mail
            await Task.CompletedTask;
        }
    }
}
