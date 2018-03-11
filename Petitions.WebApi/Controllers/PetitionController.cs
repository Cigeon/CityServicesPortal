using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Petitions.Application.DTOs;
using Petitions.Application.Interfaces;

namespace Petitions.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class PetitionController : Controller
    {
        private readonly IPetitionService _petitionService;


        public PetitionController(IPetitionService petitionService)
        {
            _petitionService = petitionService;
        }

        [HttpGet]
        public IEnumerable<PetitionDto> Get()
        {
            return _petitionService.GetAll();
        }

        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        [HttpPost]
        public void Post([FromBody]PetitionDto petition)
        {
            _petitionService.Create(petition);
        }

        [HttpPut]
        public void Put([FromBody]PetitionDto petition)
        {
            _petitionService.Update(petition);
        }

        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            _petitionService.Remove(id);
        }
    }
}
