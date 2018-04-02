using CityServicesPortal.Petitions.Domain.Models;
using System;

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
    }
}
