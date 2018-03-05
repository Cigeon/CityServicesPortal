using AutoMapper;
using Petitions.Application.DTOs;
using Petitions.Domain.WriteModel;

namespace Petitions.Application.AutoMapper
{
    public class DomainToDtoMappingProfile : Profile
    {
        public DomainToDtoMappingProfile()
        {
            CreateMap<Petition, PetitionDto>();
        }
    }
}
