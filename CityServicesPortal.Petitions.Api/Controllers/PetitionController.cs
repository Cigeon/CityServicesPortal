﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CityServicesPortal.Petitions.Application.DTOs;
using CityServicesPortal.Petitions.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CityServicesPortal.Petitions.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class PetitionController : Controller
    {
        private readonly IPetitionAppService _petitionAppService;
        private readonly IUserAppService _userAppService;

        public PetitionController(IPetitionAppService petitionAppService,
                                  IUserAppService userAppService)
        {
            _petitionAppService = petitionAppService;
            _userAppService = userAppService;
        }

        [HttpGet]
        public IEnumerable<PetitionDto> Get()
        {
            return _petitionAppService.GetAll();
        }

        [HttpGet("{id}")]
        public PetitionDto Get(Guid id)
        {
            return _petitionAppService.GetById(id);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]PetitionRegisterDto petition)
        {
            await _petitionAppService.Register(petition);
            return NoContent();
        }

        [HttpPut]
        public async Task Put([FromBody]PetitionUpdateDto petition)
        {
            await _petitionAppService.Update(petition);
        }        

        [HttpDelete("{id}")]
        public async Task Delete(Guid id)
        {
            await _petitionAppService.Remove(id);
        }

        [HttpPut]
        [Route("name")]
        public async Task ChangeName(Guid id, [FromBody]string name)
        {
            await _petitionAppService.ChangeName(id, name);
        }

        [HttpPut]
        [Route("description")]
        public async Task ChangeDescription(Guid id, [FromBody]string description)
        {
            await _petitionAppService.ChangeDescription(id, description);
        }

        [HttpPut]
        [Route("status")]
        public async Task ChangeStatus(Guid id, [FromBody]int status)
        {
            await _petitionAppService.ChangeStatus(id, status); ;
        }

        [HttpPut]
        [Route("category")]
        public async Task ChangeCategory(Guid id, [FromBody]Guid categoryId)
        {
            await _petitionAppService.ChangeCategory(id, categoryId); ;
        }

        [HttpPut]
        [Route("vote")]
        public async Task Vote(Guid id)
        {
            var user = _userAppService.GetByUserName("user");
            if (user == null)
            {
                var registerUser = new UserRegisterDto
                {
                    FirstName = "Alex"
                };

                _userAppService.Register(registerUser);

                user = new UserDto
                {
                    FirstName = registerUser.FirstName
                };
            }
            await _petitionAppService.Vote(id, user);
        }
    }
}
