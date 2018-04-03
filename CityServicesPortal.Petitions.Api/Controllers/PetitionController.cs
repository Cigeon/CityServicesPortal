﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CityServicesPortal.Petitions.Application.DTOs;
using CityServicesPortal.Petitions.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize]
        public async Task<IActionResult> Post([FromBody]PetitionRegisterDto petition)
        {
            var name = User.Claims.FirstOrDefault(c => c.Type.Equals("name")).Value;
            if (_userAppService.GetByUserName(name) == null)
            {
                var user = new UserRegisterDto
                {
                    UserName = User.Claims.FirstOrDefault(c => c.Type.Equals("name")).Value,
                    FirstName = User.Claims.FirstOrDefault(c => c.Type.Equals("first_name")).Value,
                    MiddleName = User.Claims.FirstOrDefault(c => c.Type.Equals("middle_name")).Value,
                    LastName = User.Claims.FirstOrDefault(c => c.Type.Equals("last_name")).Value
                };
                _userAppService.Register(user);
            }

            var newPetition = new PetitionRegisterDto
            {
                CategoryId = petition.CategoryId,
                Name = petition.Name,
                Description = petition.Description,
                UserName = name
            };
            await _petitionAppService.Register(newPetition);

            return NoContent();
        }


        [HttpPut]
        [Authorize]
        public async Task Put([FromBody]PetitionUpdateDto petition)
        {
            await _petitionAppService.Update(petition);
        }        

        [HttpDelete("{id}")]
        [Authorize]
        public async Task Delete(Guid id)
        {
            await _petitionAppService.Remove(id);
        }

        [HttpPut]
        [Route("name")]
        [Authorize]
        public async Task ChangeName(Guid id, [FromBody]string name)
        {
            await _petitionAppService.ChangeName(id, name);
        }

        [HttpPut]
        [Route("description")]
        [Authorize]
        public async Task ChangeDescription(Guid id, [FromBody]string description)
        {
            await _petitionAppService.ChangeDescription(id, description);
        }

        [HttpPut]
        [Route("status")]
        [Authorize]
        public async Task ChangeStatus(Guid id, [FromBody]int status)
        {
            await _petitionAppService.ChangeStatus(id, status); ;
        }

        [HttpPut]
        [Route("category")]
        [Authorize]
        public async Task ChangeCategory(Guid id, [FromBody]Guid categoryId)
        {
            await _petitionAppService.ChangeCategory(id, categoryId); ;
        }

        [HttpPut]
        [Route("vote")]
        [Authorize]
        public async Task Vote(Guid id)
        {
            var name = User.Claims.FirstOrDefault(c => c.Type.Equals("name")).Value;
            if (_userAppService.GetByUserName(name) == null)
            {
                var registerUser = new UserRegisterDto
                {
                    UserName = User.Claims.FirstOrDefault(c => c.Type.Equals("name")).Value,
                    FirstName = User.Claims.FirstOrDefault(c => c.Type.Equals("first_name")).Value,
                    MiddleName = User.Claims.FirstOrDefault(c => c.Type.Equals("middle_name")).Value,
                    LastName = User.Claims.FirstOrDefault(c => c.Type.Equals("last_name")).Value
                };
                _userAppService.Register(registerUser);
            }

            var user = new UserDto
            {

            };

            await _petitionAppService.Vote(id, user);
        }
    }
}
