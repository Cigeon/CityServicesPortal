using System;
using System.Collections.Generic;

namespace CityServicesPortal.Petitions.Application.DTOs
{
    public class CategoryDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; }
        public List<PetitionDto> Petitions { get; set; }
    }
}
