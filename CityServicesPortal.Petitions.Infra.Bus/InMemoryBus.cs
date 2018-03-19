using CityServicesPortal.Petitions.Domain.Core.Bus;
using CityServicesPortal.Petitions.Domain.Core.Commands;
using CityServicesPortal.Petitions.Domain.Core.Events;
using MediatR;
using System.Threading.Tasks;

namespace CityServicesPortal.Petitions.Infra.Bus
{
    public sealed class InMemoryBus : IMediatorHandler
    {
        private readonly IMediator _mediator;
        private readonly IEventStore _eventStore;

        public InMemoryBus(IEventStore eventStore, IMediator mediator)
        {
            _eventStore = eventStore;
            _mediator = mediator;
        }

        public async Task SendCommand<T>(T command) where T : Command
        {
            await Publish(command);
        }

        public Task RaiseEvent<T>(T @event) where T : Event
        {
            if (!@event.MessageType.Equals("DomainNotification"))
                _eventStore?.Save(@event);

            return Publish(@event);
        }

        private async Task Publish<T>(T message) where T : Message
        {
            await _mediator.Publish(message);
        }
    }
}
