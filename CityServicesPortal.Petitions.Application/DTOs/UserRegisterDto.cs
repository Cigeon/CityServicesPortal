﻿using System;

namespace CityServicesPortal.Petitions.Application.DTOs
{
    public class UserRegisterDto
    {
        public int IdentityId { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
    }
}
