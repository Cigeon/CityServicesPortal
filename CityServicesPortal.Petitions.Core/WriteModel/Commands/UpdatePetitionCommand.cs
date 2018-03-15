using CQRSlite.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace CityServicesPortal.Petitions.Core.WriteModel.Commands
{
    public class UpdatePetitionCommand : ICommand
    {
        public UpdatePetitionCommand(Guid id, int originalVersion, string name, string description)
        {
            Id = id;
            ExpectedVersion = originalVersion;
            Name = name;
            Description = description;
        }

        public Guid Id { get; set; }

        public int ExpectedVersion { get; set; }

        public string Name { get; private set; }

        public string Description { get; private set; }

    }
}
