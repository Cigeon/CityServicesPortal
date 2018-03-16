using CityServicesPortal.Petitions.Domain.Events;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CityServicesPortal.Petitions.Domain.EventHandlers
{
    public class PetitionEventHandler :
    INotificationHandler<PetitionRegisteredEvent>
    {
        public async Task Handle(PetitionRegisteredEvent message, CancellationToken cancellationToken)
        {
            // Send some notification e-mail
            await Task.CompletedTask;
        }
    }
}
