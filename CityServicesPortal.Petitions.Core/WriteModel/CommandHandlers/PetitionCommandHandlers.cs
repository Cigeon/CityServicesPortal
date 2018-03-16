using CityServicesPortal.Petitions.Core.WriteModel.Commands;
using CityServicesPortal.Petitions.Core.WriteModel.Domain;
using CQRSlite.Commands;
using CQRSlite.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CityServicesPortal.Petitions.Core.WriteModel.CommandHandlers
{
    public class PetitionCommandHandlers : ICommandHandler<CreatePetitionCommand>, 
        ICancellableCommandHandler<UpdatePetitionCommand>
    {
        private readonly ISession _session;

        public PetitionCommandHandlers(ISession session)
        {
            _session = session;
        }

        public async Task Handle(CreatePetitionCommand command)
        {
            var item = new Petition(command.Id, command.PetitionId, command.Name,
                command.Description, command.Created, command.PetitionsStatus, command.PetitionAreaId,
                command.PetitionUserId, command.PetitionVoters);
            //await _session.Add(item);
            //await _session.Commit();
            await Task.CompletedTask;
        }

        public async Task Handle(UpdatePetitionCommand command, CancellationToken token)
        {
            var item = await _session.Get<Petition>(command.Id, command.ExpectedVersion, token);
            item.Update(command.Name, command.Description);
            await _session.Commit(token);
        }
    }
}
