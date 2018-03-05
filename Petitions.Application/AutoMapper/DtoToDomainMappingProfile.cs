using AutoMapper;
using Petitions.Application.DTOs;
using Petitions.Domain.Commands;

namespace Petitions.Application.AutoMapper
{
    public class DtoToDomainMappingProfile : Profile
    {
        public DtoToDomainMappingProfile()
        {
            CreateMap<PetitionDto, CreatePetitionCommand>()
                .ConstructUsing(p => new CreatePetitionCommand(p.Id, p.PetitionId, p.Name, 
                        p.Description, p.Created, p.PetitionsStatus, p.PetitionAreaId,
                        p.PetitionUserId, p.PetitionVoters));
        }
    }
}
