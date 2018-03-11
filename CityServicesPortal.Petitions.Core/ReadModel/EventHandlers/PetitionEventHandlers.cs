using CityServicesPortal.Petitions.Core.ReadModel.Dtos;
using CityServicesPortal.Petitions.Core.ReadModel.Events;
using CityServicesPortal.Petitions.Core.ReadModel.Infrastructure;
using CQRSlite.Events;
using System.Threading;
using System.Threading.Tasks;

namespace CityServicesPortal.Petitions.Core.ReadModel.EventHandlers
{
    public class PetitionEventHandlers : ICancellableEventHandler<PetitionCreated>
    {
        public Task Handle(PetitionCreated petition, CancellationToken token = default(CancellationToken))
        {
            InMemoryDatabase.List.Add(new PetitionDto
            {
                Id = petition.Id,
                PetitionId = petition.PetitionId,
                Name = petition.Name,
                Description = petition.Description,
                Created = petition.Created,
                PetitionsStatus = petition.PetitionsStatus,
                PetitionAreaId = petition.PetitionAreaId,
                PetitionUserId = petition.PetitionUserId,
                PetitionVoters = petition.PetitionVoters

            });
            return Task.CompletedTask;
        }
    }
}
