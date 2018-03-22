using CityServicesPortal.Petitions.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CityServicesPortal.Petitions.Application.Interfaces
{
    public interface ICategoryAppService
    {
        Task Create(CategoryCreateDto category);
        IEnumerable<CategoryDto> GetAll();
        CategoryDto GetById(Guid id);
        Task Update(CategoryUpdateDto category);
        Task Remove(Guid id);
        Task ChangeName(Guid id, string name);
        Task ChangeDescription(Guid id, string description);
    }
}
