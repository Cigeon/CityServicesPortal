using System;
using System.Collections.Generic;
using System.Text;

namespace Petitions.Domain.WriteModel
{
    public class PetitionUser
    {
        public PetitionUser(int id, 
                            int identityId, 
                            string firstName, 
                            string middleName, 
                            string lastName, 
                            List<Petition> petitions,
                            List<PetitionVoter> petitionVoters)
        {
            Id = id;
            IdentityId = identityId;
            FirstName = firstName;
            MiddleName = middleName;
            LastName = lastName;
            Petitions = petitions;
            PetitionVoters = petitionVoters;
        }

        public int Id { get; private set; }

        public int IdentityId { get; private set; }

        public string FirstName { get; private set; }

        public string MiddleName { get; private set; }

        public string LastName { get; private set; }

        public List<Petition> Petitions { get; private set; }

        public List<PetitionVoter> PetitionVoters { get; private set; }
    }
}
