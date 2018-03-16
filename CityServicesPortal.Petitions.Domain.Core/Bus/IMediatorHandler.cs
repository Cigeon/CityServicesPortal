using CityServicesPortal.Petitions.Domain.Core.Commands;
using CityServicesPortal.Petitions.Domain.Core.Events;
using System.Threading.Tasks;

namespace CityServicesPortal.Petitions.Domain.Core.Bus
{
    public interface IMediatorHandler
    {
        Task SendCommand<T>(T command) where T : Command;
        Task RaiseEvent<T>(T @event) where T : Event;
    }
}
