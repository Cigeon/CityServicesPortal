using System;
using System.ComponentModel.DataAnnotations;

namespace CityServicesPortal.Petitions.Application.ViewModels
{
    public class PetitionViewModel
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; }
    }
}
