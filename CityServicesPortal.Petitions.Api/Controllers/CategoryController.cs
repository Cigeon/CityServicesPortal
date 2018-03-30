using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CityServicesPortal.Petitions.Application.DTOs;
using CityServicesPortal.Petitions.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CityServicesPortal.Petitions.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [Authorize]
    public class CategoryController : Controller
    {
        private readonly ICategoryAppService _categoryAppService;

        public CategoryController(ICategoryAppService categoryAppService)
        {
            _categoryAppService = categoryAppService;
        }

        [HttpGet]
        public IEnumerable<CategoryDto> Get()
        {
            return _categoryAppService.GetAll();
        }

        [HttpGet("{id}")]
        public CategoryDto Get(Guid id)
        {
            return _categoryAppService.GetById(id);
        }

        [HttpPost]
        public async Task Post([FromBody]CategoryCreateDto category)
        {
            await _categoryAppService.Create(category);
        }

        [HttpPut]
        public async Task Put([FromBody]CategoryUpdateDto category)
        {
            await _categoryAppService.Update(category);
        }

        [HttpDelete("{id}")]
        public async Task Delete(Guid id)
        {
            await _categoryAppService.Remove(id);
        }

        [HttpPut]
        [Route("name")]
        public async Task ChangeName(Guid id, [FromBody]string name)
        {
            await _categoryAppService.ChangeName(id, name);
        }

        [HttpPut]
        [Route("description")]
        public async Task ChangeDescription(Guid id, [FromBody]string description)
        {
            await _categoryAppService.ChangeDescription(id, description);
        }
    }
}