using CityServicesPortal.Petitions.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CityServicesPortal.Petitions.Application.Interfaces
{
    public interface IPetitionAppService : IDisposable
    {
        Task Register(PetitionRegisterDto dto);
        IEnumerable<PetitionDto> GetAll();
        PetitionDto GetById(Guid id);
        Task Update(PetitionUpdateDto dto);
        Task Remove(Guid id);
        Task ChangeName(Guid id, string name);
        Task ChangeDescription(Guid id, string description);
        Task ChangeStatus(Guid id, int status);
        Task ChangeCategory(Guid id, Guid categoryId);
        void Vote(Guid petitionId, Guid userId);
        //IList<CustomerHistoryData> GetAllHistory(Guid id);
    }
}
