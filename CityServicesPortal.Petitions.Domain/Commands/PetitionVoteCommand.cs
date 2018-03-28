using CityServicesPortal.Petitions.Domain.Core.Commands;
using System;

namespace CityServicesPortal.Petitions.Domain.Commands
{
    public class PetitionVoteCommand : Command
    {
        public PetitionVoteCommand(Guid id, Guid userId, string userFirstName, string userMiddleName, string userLastName)
        {
            Id = id;
            UserId = userId;
            UserFirstName = userFirstName;
            UserMiddleName = userMiddleName;
            UserLastName = userLastName;
        }

        public Guid Id { get; protected set; }
        public Guid UserId { get; protected set; }
        public string UserFirstName { get; protected set; }
        public string UserMiddleName { get; protected set; }
        public string UserLastName { get; protected set; }
    }
}
