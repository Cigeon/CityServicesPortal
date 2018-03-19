using CityServicesPortal.Petitions.Domain.Core.Commands;
using CityServicesPortal.Petitions.Domain.Models;
using System;

namespace CityServicesPortal.Petitions.Domain.Commands
{
    public class PetitionChangeStatusCommand : Command
    {
        public PetitionChangeStatusCommand(Guid id, PetitionStatus status)
        {
            Id = id;
            Status = status;
        }

        public Guid Id { get; protected set; }
        public PetitionStatus Status { get; protected set; }
    }
}
