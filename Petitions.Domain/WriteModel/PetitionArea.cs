using CQRSlite.Domain;
using System;
using System.Collections.Generic;

namespace Petitions.Domain.WriteModel
{
    public class PetitionArea : AggregateRoot
    {
        public PetitionArea() {  }

        public PetitionArea(Guid id, int petitionAreaId, string name, 
            string description, DateTime created, List<int> petitions)
        {
            Id = id;
            PetitionAreaId = petitionAreaId;
            Name = name;
            Description = description;
            Created = created;
            Petitions = petitions;

            //ApplyChange
        }

        public int PetitionAreaId { get; private set; }

        public string Name { get; private set; }

        public string Description { get; private set; }

        public DateTime Created { get; private set; }

        public List<int> Petitions { get; private set; }
    }
}
