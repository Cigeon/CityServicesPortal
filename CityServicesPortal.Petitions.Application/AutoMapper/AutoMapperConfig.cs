﻿using AutoMapper;

namespace CityServicesPortal.Petitions.Application.AutoMapper
{
    public class AutoMapperConfig
    {

        public static MapperConfiguration RegisterMappings()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new DomainToViewModelMappingProfile());
                cfg.AddProfile(new ViewModelToDomainMappingProfile());
            });
        }
    }
}
