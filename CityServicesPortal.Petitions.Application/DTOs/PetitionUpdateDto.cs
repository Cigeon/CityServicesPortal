﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CityServicesPortal.Petitions.Application.DTOs
{
    public class PetitionUpdateDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid CategoryId { get; set; }
    }
}
