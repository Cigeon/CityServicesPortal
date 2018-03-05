using Petitions.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Petitions.Application.Interfaces
{
    public interface IPetitionService : IDisposable
    {
        void Create(PetitionDto petition);
        IEnumerable<PetitionDto> GetAll();
        PetitionDto GetById(Guid id);
        void Update(PetitionDto petition);
        void Remove(Guid id);
        //IList<CustomerHistoryData> GetAllHistory(Guid id);
    }
}
