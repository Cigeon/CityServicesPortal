using System.Collections.Generic;

namespace Petitions.Domain.ReadModel.Repositories.Interfaces
{
    public interface IPetitionRepository : IBaseRepository<PetitionRM>
    {
        IEnumerable<PetitionRM> GetAll();
    }
}
