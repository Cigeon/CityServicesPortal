using System;
using System.Collections.Generic;

namespace CityServicesPortal.Petitions.Application.DTOs
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public int IdentityId { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public List<PetitionDto> Petitions { get; set; }
        public List<PetitionDto> VotedPetitions { get; set; }
    }
}
