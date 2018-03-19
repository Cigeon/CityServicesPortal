using AutoMapper;
using CityServicesPortal.Petitions.Application.DTOs;
using CityServicesPortal.Petitions.Domain.Commands;

namespace CityServicesPortal.Petitions.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<PetitionDto, RegisterPetitionCommand>()
                .ConstructUsing(p => new RegisterPetitionCommand(p.Name, p.Description, p.Created, p.CategoryId))
                .ForMember(x => x.Timestamp, opt => opt.Ignore());
        }
    }
}
