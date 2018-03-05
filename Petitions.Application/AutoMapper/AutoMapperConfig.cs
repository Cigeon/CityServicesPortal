﻿using AutoMapper;

namespace Petitions.Application.AutoMapper
{
    public class AutoMapperConfig
    {

        public static MapperConfiguration RegisterMappings()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new DomainToDtoMappingProfile());
                cfg.AddProfile(new DtoToDomainMappingProfile());
            });
        }
    }
}
