using CityServicesPortal.Petitions.Domain.Core.Commands;
using CityServicesPortal.Petitions.Domain.Interfaces;
using CityServicesPortal.Petitions.Infra.Data.Context;

namespace CityServicesPortal.Petitions.Infra.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PetitionContext _context;

        public UnitOfWork(PetitionContext context)
        {
            _context = context;
        }

        public CommandResponse Commit()
        {
            var rowsAffected = _context.SaveChanges();
            return new CommandResponse(rowsAffected > 0);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
