using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using CityServicesPortal.Petitions.Core.ReadModel.Dtos;
using CityServicesPortal.Petitions.Core.ReadModel.Infrastructure;
using CityServicesPortal.Petitions.Core.WriteModel.Commands;
using CQRSlite.Commands;
using Microsoft.AspNetCore.Mvc;

namespace CityServicesPortal.Petitions.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class PetitionController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ICommandSender _commandSender;
        private readonly IReadModelFacade _readmodel;

        public PetitionController(IMapper mapper, ICommandSender commandSender, IReadModelFacade readmodel)
        {
            _mapper = mapper;
            _readmodel = readmodel;
            _commandSender = commandSender;
        }

        [HttpGet]
        public IEnumerable<PetitionDto> Get()
        {
            return _readmodel.GetInventoryItems();
        }

        [HttpGet("{id}")]
        public PetitionDto Get(Guid id)
        {
            return _readmodel.GetInventoryItemDetails(id);
        }

        [HttpPost]
        public async Task Post([FromBody]PetitionDto petition, CancellationToken cancellationToken)
        {
            var command = _mapper.Map<CreatePetitionCommand>(petition);
            await _commandSender.Send(command, cancellationToken);
        }

        [HttpPut]
        public void Put([FromBody]PetitionDto petition)
        {            
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
