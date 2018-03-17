using AutoMapper;
using CityServicesPortal.Petitions.Application.ViewModels;
using CityServicesPortal.Petitions.Domain.Commands;

namespace CityServicesPortal.Petitions.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            //CreateMap<PetitionViewModel, RegisterPetitionCommand>()
            //    .ConstructUsing(p => new RegisterPetitionCommand(p.Name, p.Description, p.Created))
            //    .ForMember(x => x.Timestamp, opt => opt.Ignore());


        }
    }
}
