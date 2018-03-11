using AutoMapper;
using CQRSlite.Events;
using Petitions.Domain.Events;
using Petitions.Domain.ReadModel;
using Petitions.Domain.ReadModel.Repositories.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace Petitions.Domain.EventHandlers
{
    public class PetitionEventHandler : IEventHandler<PetitionCreatedEvent>
    {
        private readonly IMapper _mapper;
        private readonly IPetitionRepository _petitionRepo;
        public PetitionEventHandler(IMapper mapper, IPetitionRepository petitionRepo)
        {
            _mapper = mapper;
            _petitionRepo = petitionRepo;
        }

        public Task Handle(PetitionCreatedEvent message)
        {
            PetitionRM employee = _mapper.Map<PetitionRM>(message);
            _petitionRepo.Save(employee);
            return Task.CompletedTask;
        }
    }
}
