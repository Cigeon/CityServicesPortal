using System;
using System.Collections.Generic;
using System.Text;

namespace CityServicesPortal.Petitions.Application.DTOs
{
    public class ReviewDto
    {
        public Guid Id { get; set; }
        public DateTime Created { get; set; }
        public UserShortDto User { get; set; }
        public string Text { get; set; }
    }
}
