using CityServicesPortal.Petitions.Core.WriteModel.Commands;
using CityServicesPortal.Petitions.Core.WriteModel.Domain;
using CQRSlite.Commands;
using CQRSlite.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CityServicesPortal.Petitions.Core.WriteModel.CommandHandlers
{
    public class PetitionCommandHandlers : ICommandHandler<CreatePetitionCommand>
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
            await _session.Add(item);
            await _session.Commit();
        }
    }
}
