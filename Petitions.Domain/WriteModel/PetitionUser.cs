using CQRSlite.Domain;
using System;
using System.Collections.Generic;

namespace Petitions.Domain.WriteModel
{
    public class PetitionUser : AggregateRoot
    {
        public PetitionUser() {  }

        public PetitionUser(Guid id, int petitionUserId, int identityId, 
            string firstName, string middleName, string lastName, 
            List<int> createdPetitions, List<PetitionVoter> votedPetitions)
        {
            Id = id;
            PetitionUserId = petitionUserId;
            IdentityId = identityId;
            FirstName = firstName;
            MiddleName = middleName;
            LastName = lastName;
            CreatedPetitions = createdPetitions;
            VotedPetitions = votedPetitions;

            //ApplyChange
        }

        public int PetitionUserId { get; private set; }

        public int IdentityId { get; private set; }

        public string FirstName { get; private set; }

        public string MiddleName { get; private set; }

        public string LastName { get; private set; }

        public List<int> CreatedPetitions { get; private set; }

        public List<PetitionVoter> VotedPetitions { get; private set; }
    }
}
