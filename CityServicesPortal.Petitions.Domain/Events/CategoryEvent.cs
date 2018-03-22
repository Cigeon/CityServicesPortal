using CityServicesPortal.Petitions.Domain.Core.Events;
using CityServicesPortal.Petitions.Domain.Models;
using System;
using System.Collections.Generic;

namespace CityServicesPortal.Petitions.Domain.Events
{
    public class CategoryEvent : Event
    {
        public CategoryEvent(Category category)
        {
            Id = category.Id;
            AggregateId = category.Id;
            Name = category.Name;
            Description = category.Description;
            Created = DateTime.Now;
            Modified = DateTime.Now;
            Petitions = category.Petitions;
        }

        public Guid Id { get; private set; }

        public string Name { get; private set; }

        public string Description { get; private set; }

        public DateTime Created { get; private set; }

        public DateTime Modified { get; private set; }

        public List<Petition> Petitions { get; set; }
    }
}
