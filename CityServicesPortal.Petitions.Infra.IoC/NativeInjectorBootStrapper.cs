﻿using AutoMapper;
using CityServicesPortal.Petitions.Application.Interfaces;
using CityServicesPortal.Petitions.Application.Services;
using CityServicesPortal.Petitions.Domain.CommandHandlers;
using CityServicesPortal.Petitions.Domain.Commands;
using CityServicesPortal.Petitions.Domain.Core.Bus;
using CityServicesPortal.Petitions.Domain.Core.Events;
using CityServicesPortal.Petitions.Domain.Core.Notifications;
using CityServicesPortal.Petitions.Domain.EventHandlers;
using CityServicesPortal.Petitions.Domain.Events;
using CityServicesPortal.Petitions.Domain.Interfaces;
using CityServicesPortal.Petitions.Infra.Bus;
using CityServicesPortal.Petitions.Infra.Data.Context;
using CityServicesPortal.Petitions.Infra.Data.EventSourcing;
using CityServicesPortal.Petitions.Infra.Data.Repository;
using CityServicesPortal.Petitions.Infra.Data.Repository.EventSourcing;
using CityServicesPortal.Petitions.Infra.Data.UoW;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace CityServicesPortal.Petitions.Infra.IoC
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // ASP.NET HttpContext dependency
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            // Domain Bus (Mediator)
            services.AddScoped<IMediatorHandler, InMemoryBus>();

            // ASP.NET Authorization Polices
            //services.AddSingleton<IAuthorizationHandler, ClaimsRequirementHandler>(); ;

            // Application
            services.AddSingleton(Mapper.Configuration);
            services.AddScoped<IMapper>(sp => new Mapper(sp.GetRequiredService<IConfigurationProvider>(), sp.GetService));
            services.AddScoped<IPetitionAppService, PetitionAppService>();

            // Domain - Events
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();
            services.AddScoped<INotificationHandler<PetitionRegisteredEvent>, PetitionEventHandler>();
            services.AddScoped<INotificationHandler<PetitionUpdatedEvent>, PetitionEventHandler>();
            services.AddScoped<INotificationHandler<PetitionRemovedEvent>, PetitionEventHandler>();
            services.AddScoped<INotificationHandler<PetitionNameChangedEvent>, PetitionEventHandler>();
            services.AddScoped<INotificationHandler<PetitionDescriptionChangedEvent>, PetitionEventHandler>();
            services.AddScoped<INotificationHandler<PetitionStatusChangedEvent>, PetitionEventHandler>();

            // Domain - Commands
            services.AddScoped<INotificationHandler<RegisterPetitionCommand>, PetitionCommandHandler>();
            services.AddScoped<INotificationHandler<UpdatePetitionCommand>, PetitionCommandHandler>();
            services.AddScoped<INotificationHandler<RemovePetitionCommand>, PetitionCommandHandler>();
            services.AddScoped<INotificationHandler<PetitionChangeNameCommand>, PetitionCommandHandler>();
            services.AddScoped<INotificationHandler<PetitionChangeDescriptionCommand>, PetitionCommandHandler>();
            services.AddScoped<INotificationHandler<PetitionChangeStatusCommand>, PetitionCommandHandler>();

            // Infra - Data
            services.AddScoped<IPetitionRepository, PetitionRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<PetitionContext>();

            // Infra - Data EventSourcing
            services.AddScoped<IEventStoreRepository, EventStoreSQLRepository>();
            services.AddScoped<IEventStore, SqlEventStore>();
            services.AddScoped<EventStoreSQLContext>();

            // Infra - Identity Services
            //services.AddTransient<IEmailSender, AuthEmailMessageSender>();
            //services.AddTransient<ISmsSender, AuthSMSMessageSender>();

            // Infra - Identity
            //services.AddScoped<IUser, AspNetUser>();
        }
    }
}
