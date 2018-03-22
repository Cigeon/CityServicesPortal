using CityServicesPortal.Petitions.Domain.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace CityServicesPortal.Petitions.Application.DTOs
{
    public class PetitionDto
    {
        //[Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
        public PetitionStatus Status { get; set; }
        public Guid CategoryId { get; set; }
    }
}
