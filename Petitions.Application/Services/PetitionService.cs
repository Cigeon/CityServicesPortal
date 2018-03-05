using AutoMapper;
using Petitions.Application.DTOs;
using Petitions.Application.Interfaces;
using Petitions.Domain.Commands;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Petitions.Application.Services
{
    public class PetitionService : IPetitionService
    {
        private readonly IMapper _mapper;

        public PetitionService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public void Create(PetitionDto petition)
        {
            var createCommand = _mapper.Map<CreatePetitionCommand>(petition);
            Debug.WriteLine("Petition created");
        }

        public IEnumerable<PetitionDto> GetAll()
        {
            return new List<PetitionDto>
            {
                new PetitionDto
                {
                    Id = Guid.NewGuid(),
                    Name = "Petition"
                }
            };
        }

        public PetitionDto GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Remove(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Update(PetitionDto petition)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
