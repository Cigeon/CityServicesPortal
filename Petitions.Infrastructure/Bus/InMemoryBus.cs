using MediatR;
using Petitions.Domain.Commands;
using Petitions.Domain.Events;
using Petitions.Domain.Interfaces;
using Petitions.Infrastructure.Repository.EventSourcing;
using System.Threading.Tasks;

namespace Petitions.Infrastructure.Bus
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

        public Task SendCommand<T>(T command) where T : BaseCommand
        {
            return Publish(command);
        }

        public Task RaiseEvent<T>(T @event) where T : StoredEvent
        {
            if (!@event.MessageType.Equals("DomainNotification"))
                _eventStore?.Save(@event);

            return Publish(@event);
        }

        private Task Publish<T>(T message) where T : Message
        {
            return _mediator.Publish(message);
        }
    }
}
