using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CityServicesPortal.Petitions.Application.DTOs;
using CityServicesPortal.Petitions.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CityServicesPortal.Petitions.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]    
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
        [Authorize]
        public async Task<IActionResult> Post([FromBody]CategoryCreateDto category)
        {
            await _categoryAppService.Create(category);
            return NoContent();
        }

        [HttpPut]
        [Authorize]
        public async Task Put([FromBody]CategoryUpdateDto category)
        {
            await _categoryAppService.Update(category);
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task Delete(Guid id)
        {
            await _categoryAppService.Remove(id);
        }

        [HttpPut]
        [Route("name")]
        [Authorize]
        public async Task ChangeName(Guid id, [FromBody]string name)
        {
            await _categoryAppService.ChangeName(id, name);
        }

        [HttpPut]
        [Route("description")]
        [Authorize]
        public async Task ChangeDescription(Guid id, [FromBody]string description)
        {
            await _categoryAppService.ChangeDescription(id, description);
        }
    }
}