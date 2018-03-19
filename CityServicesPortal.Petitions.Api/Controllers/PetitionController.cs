using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CityServicesPortal.Petitions.Application.DTOs;
using CityServicesPortal.Petitions.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CityServicesPortal.Petitions.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/Petition")]
    public class PetitionController : Controller
    {
        private readonly IPetitionAppService _petitionAppService;
        public PetitionController(IPetitionAppService petitionAppService)
        {
            _petitionAppService = petitionAppService;
        }

        [HttpGet]
        public IEnumerable<PetitionDto> Get()
        {
            return _petitionAppService.GetAll();
        }

        [HttpGet("{id}", Name = "Get")]
        public PetitionDto Get(Guid id)
        {
            return _petitionAppService.GetById(id);
        }

        [HttpPost]
        public async Task Post([FromBody]PetitionRegisterDto p)
        {
            await _petitionAppService.Register(p);
        }

        [HttpPut]
        public async Task Put([FromBody]PetitionUpdateDto p)
        {
            await _petitionAppService.Update(p);
        }

        [HttpPut]
        [Route("Status")]
        public async Task ChangeStatus([FromBody]PetitionChangeStatusDto p)
        {
            await _petitionAppService.ChangeStatus(p);
        }

        [HttpDelete("{id}")]
        public async Task Delete(Guid id)
        {
            await _petitionAppService.Remove(id);
        }
    }
}
