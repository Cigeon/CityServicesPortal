using CQRSlite.Commands;
using CQRSlite.Domain;
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
        private readonly ISession _session;

        public PetitionCommandHandler(ISession session)
        {
            _session = session;
        }

        public async Task Handle(CreatePetitionCommand command)
        {
            var petition = new Petition(command.Id, command.PetitionId, command.Name,
                command.Description, command.Created, command.PetitionsStatus, command.PetitionAreaId,
                command.PetitionUserId, command.PetitionVoters);            
            await _session.Add(petition);
            await _session.Commit();
        }
    }
}
