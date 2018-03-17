using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CityServicesPortal.Petitions.Application.Interfaces;
using CityServicesPortal.Petitions.Application.ViewModels;
using CityServicesPortal.Petitions.Domain.Commands;
using Microsoft.AspNetCore.Http;
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

        // GET: api/Petition
        [HttpGet]
        public IEnumerable<PetitionViewModel> Get()
        {
            var petitions = _petitionAppService.GetAll();
            return petitions;
        }

        // GET: api/Petition/030ffb2b-33b5-41be-88c4-8bc95755be9f
        [HttpGet("{id}", Name = "Get")]
        public PetitionViewModel Get(Guid id)
        {
            var petitionViewModel = _petitionAppService.GetById(id);

            return petitionViewModel;
        }
        
        // POST: api/Petition
        [HttpPost]
        public void Post([FromBody]PetitionViewModel petitionViewModel)
        {            
            _petitionAppService.Register(petitionViewModel);
        }
        
        // PUT: api/Petition/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
