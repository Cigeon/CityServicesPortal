using AutoMapper;
using CityServicesPortal.Petitions.Application.DTOs;
using CityServicesPortal.Petitions.Domain.Commands;
using CityServicesPortal.Petitions.Domain.Models;

namespace CityServicesPortal.Petitions.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<PetitionDto, PetitionRegisterCommand>()
                .ConstructUsing(p => new PetitionRegisterCommand(p.Name, p.Description, p.Created, p.CategoryId))
                .ForMember(x => x.Timestamp, opt => opt.Ignore());
            CreateMap<CategoryDto, Category > ();

        }
    }
}
