using CityServicesPortal.Petitions.Application.DTOs;
using CityServicesPortal.Petitions.Application.Interfaces;
using CityServicesPortal.Petitions.Domain.Commands;
using CityServicesPortal.Petitions.Domain.Core.Bus;
using CityServicesPortal.Petitions.Domain.Interfaces;
using CityServicesPortal.Petitions.Infra.Data.Repository.EventSourcing;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace CityServicesPortal.Petitions.Application.Services
{
    public class CategoryAppService : ICategoryAppService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IEventStoreRepository _eventStoreRepository;
        private readonly IMediatorHandler Bus;

        public CategoryAppService(ICategoryRepository categoryRepository, 
                                  IEventStoreRepository eventStoreRepository, 
                                  IMediatorHandler bus)
        {
            _categoryRepository = categoryRepository;
            _eventStoreRepository = eventStoreRepository;
            Bus = bus;
        }

        public IEnumerable<CategoryDto> GetAll()
        {
            var categories = _categoryRepository.GetAll()
                .Include(c => c.Petitions)
                .Select(c => new CategoryDto
                {
                    Id = c.Id,
                    Name = c.Name,
                    Description = c.Description,
                    Created = c.Created,
                    Modified = c.Modified,
                    Petitions = c.Petitions.Select(p => new PetitionDto
                    {
                        Id = p.Id,
                        Name = p.Name,
                        Description = p.Description,
                        Created = p.Created,
                        Modified = p.Modified,
                        Status = p.Status
                    }).ToList()
                });

            return categories;

        }

        public CategoryDto GetById(Guid id)
        {
            var category = _categoryRepository.GetById(id);
            return new CategoryDto
            {
                Id = category.Id,
                Name = category.Name,
                Description = category.Description,
                Created = category.Created,
                Modified = category.Modified,
                Petitions = category.Petitions?.Select(p => new PetitionDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    Description = p.Description,
                    Created = p.Created,
                    Modified = p.Modified,
                    Status = p.Status
                }).ToList()
            };
        }

        public async Task Create(CategoryCreateDto c)
        {
            var createCommand = new CategoryCreateCommand(c.Name, c.Description, DateTime.Now,
                DateTime.Now);
            await Bus.SendCommand(createCommand);
        }        

        public async Task Update(CategoryUpdateDto c)
        {
            var updateCommand = new CategoryUpdateCommand(c.Id, c.Name, c.Description);
            await Bus.SendCommand(updateCommand);
        }

        public async Task Remove(Guid id)
        {
            var removeCommand = new CategoryRemoveCommand(id);
            await Bus.SendCommand(removeCommand);
        }

        public async Task ChangeName(Guid id, string name)
        {
            var changeNameCommand = new CategoryChangeNameCommand(id, name);
            await Bus.SendCommand(changeNameCommand);
        }

        public async Task ChangeDescription(Guid id, string description)
        {
            var changeDescriptionCommand = new CategoryChangeDescriptionCommand(id, description);
            await Bus.SendCommand(changeDescriptionCommand);
        }
    }
}
