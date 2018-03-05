using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Petitions.Application.DTOs;
using Petitions.Application.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

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

        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<PetitionDto> Get()
        {
            return _petitionService.GetAll();
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]PetitionDto petition)
        {
            _petitionService.Create(petition);
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
