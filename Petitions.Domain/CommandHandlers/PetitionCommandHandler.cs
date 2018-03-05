using CQRSlite.Commands;
using CQRSlite.Messages;
using Petitions.Domain.Commands;
using Petitions.Domain.Interfaces;
using Petitions.Domain.WriteModel;
using System;
using System.Threading.Tasks;

namespace Petitions.Domain.CommandHandlers
{
    public class PetitionCommandHandler : ICommandHandler<CreatePetitionCommand>
    {
        private readonly IRepository<Petition> _repo;

        public PetitionCommandHandler(IRepository<Petition> repo)
        {
            _repo = repo;
        }

        public async Task Handle(CreatePetitionCommand command)
        {
            var petition = new Petition(command.Id, command.PetitionId, command.Name,
                command.Description, command.Created, command.PetitionsStatus, command.PetitionAreaId,
                command.PetitionUserId, command.PetitionVoters);

            await _repo.AddAsync(petition);
            await _repo.SaveChangesAsync();
        }
        
    }
}
