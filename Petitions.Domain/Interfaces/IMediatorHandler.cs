using Petitions.Domain.Commands;
using Petitions.Domain.Events;
using System.Threading.Tasks;

namespace Petitions.Domain.Interfaces
{
    public interface IMediatorHandler
    {
        Task SendCommand<T>(T command) where T : BaseCommand;
        Task RaiseEvent<T>(T @event) where T : BaseEvent;
    }
}
