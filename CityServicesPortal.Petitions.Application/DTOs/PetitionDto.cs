using CityServicesPortal.Petitions.Domain.Models;
using System;
using System.Collections.Generic;

namespace CityServicesPortal.Petitions.Application.DTOs
{
    public class PetitionDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
        public PetitionStatus Status { get; set; }
        public CategoryShortDto Category { get; set; }
        public UserShortDto User { get; set; }
        public List<UserShortDto> Voters { get; set; }
        public ReviewDto Review { get; set; }

        public PetitionDto()
        {
            Voters = new List<UserShortDto>();
        }
    }
}
