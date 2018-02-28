using System;
using System.Collections.Generic;
using System.Text;

namespace Petitions.Domain.WriteModel
{
    public class PetitionArea
    {
        public PetitionArea(int id, 
                            string name, 
                            string description, 
                            DateTime created, 
                            List<Petition> petitions)
        {
            Id = id;
            Name = name;
            Description = description;
            Created = created;
            Petitions = petitions;
        }

        public int Id { get; private set; }

        public string Name { get; private set; }

        public string Description { get; private set; }

        public DateTime Created { get; private set; }

        public List<Petition> Petitions { get; private set; }
    }
}
