using AutoMapper;
using CityServicesPortal.Petitions.Core.ReadModel.Dtos;
using CityServicesPortal.Petitions.Core.WriteModel.Commands;

namespace CityServicesPortal.Petitions.WebApi.AutoMapper
{
    public class DomainProfile : Profile
    {
        public DomainProfile()
        {
            CreateMap<PetitionDto, CreatePetitionCommand>()
                .ConstructUsing(p => new CreatePetitionCommand(p.Id, p.PetitionId, p.Name,
                        p.Description, p.Created, p.PetitionsStatus, p.PetitionAreaId,
                        p.PetitionUserId, p.PetitionVoters));
            CreateMap<PetitionDto, UpdatePetitionCommand>()
                .ConstructUsing(p => new UpdatePetitionCommand(p.Id, p.Version, p.Name, p.Description));
        }
    }
}
