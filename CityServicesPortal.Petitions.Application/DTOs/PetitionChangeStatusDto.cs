using CityServicesPortal.Petitions.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CityServicesPortal.Petitions.Application.DTOs
{
    public class PetitionChangeStatusDto
    {
        public Guid Id { get; set; }
        public PetitionStatus Status { get; set; }
    }
}
