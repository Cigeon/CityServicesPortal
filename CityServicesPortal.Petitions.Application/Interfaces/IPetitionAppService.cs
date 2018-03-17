using CityServicesPortal.Petitions.Application.ViewModels;
using System;
using System.Collections.Generic;

namespace CityServicesPortal.Petitions.Application.Interfaces
{
    public interface IPetitionAppService : IDisposable
    {
        void Register(PetitionViewModel petitionViewModel);
        IEnumerable<PetitionViewModel> GetAll();
        PetitionViewModel GetById(Guid id);
        void Update(PetitionViewModel petitionViewModel);
        void Remove(Guid id);
        //IList<CustomerHistoryData> GetAllHistory(Guid id);
    }
}
