using AutoMapper;
using CityServicesPortal.Petitions.Application.DTOs;
using CityServicesPortal.Petitions.Domain.Models;

namespace CityServicesPortal.Petitions.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Petition, PetitionDto>();
        }
    }
}
