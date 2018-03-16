using CityServicesPortal.Petitions.Domain.Core.Commands;
using System;

namespace CityServicesPortal.Petitions.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        CommandResponse Commit();
    }
}
