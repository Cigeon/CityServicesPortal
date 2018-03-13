using System;
using System.Linq;
using System.Reflection;
using AutoMapper;
using CityServicesPortal.Petitions.Core.ReadModel.Infrastructure;
using CityServicesPortal.Petitions.Core.WriteModel.CommandHandlers;
using CityServicesPortal.Petitions.Core.WriteModel.Infrastructure;
using CQRSlite.Caching;
using CQRSlite.Commands;
using CQRSlite.Domain;
using CQRSlite.Events;
using CQRSlite.Routing;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Http;
using CQRSlite.Messages;
using CityServicesPortal.Petitions.Core.WriteModel.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace CityServicesPortal.Petitions.WebApi
{
    public class Startup
    {
        //public Startup(IConfiguration configuration)
        //{
        //    Configuration = configuration;
        //}

        //public IConfiguration Configuration { get; }

        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            //services.AddDbContext<EventStoreContext>(options =>
            //                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));


            services.AddMemoryCache();

            //Add Cqrs services
            services.AddSingleton<Router>(new Router());
            services.AddSingleton<ICommandSender>(y => y.GetService<Router>());
            services.AddSingleton<IEventPublisher>(y => y.GetService<Router>());
            services.AddSingleton<IHandlerRegistrar>(y => y.GetService<Router>());
            //services.AddSingleton<IEventStore, InMemoryEventStore>();
            services.AddSingleton<IEventStore, SqlEventStore>();
            services.AddSingleton<ICache, MemoryCache>();
            services.AddScoped<IRepository>(y => new CacheRepository(new Repository(y.GetService<IEventStore>()), y.GetService<IEventStore>(), y.GetService<ICache>()));
            services.AddScoped<CQRSlite.Domain.ISession, Session>();

            services.AddTransient<IReadModelFacade, ReadModelFacade>();

            //Scan for commandhandlers and eventhandlers
            services.Scan(scan => scan
                .FromAssemblies(typeof(PetitionCommandHandlers).GetTypeInfo().Assembly)
                    .AddClasses(classes => classes.Where(x => {
                        var allInterfaces = x.GetInterfaces();
                        return
                            allInterfaces.Any(y => y.GetTypeInfo().IsGenericType && y.GetTypeInfo().GetGenericTypeDefinition() == typeof(IHandler<>)) ||
                            allInterfaces.Any(y => y.GetTypeInfo().IsGenericType && y.GetTypeInfo().GetGenericTypeDefinition() == typeof(ICancellableHandler<>));
                    }))
                    .AsSelf()
                    .WithTransientLifetime()
            );
            services.AddMvc();
            services.AddAutoMapper();

            //Register routes
            var serviceProvider = services.BuildServiceProvider();
            var registrar = new RouteRegistrar(new Provider(serviceProvider));
            registrar.RegisterInAssemblyOf(typeof(PetitionCommandHandlers));

            return serviceProvider;
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }

        //This makes scoped services work inside router.
        public class Provider : IServiceProvider
        {
            private readonly ServiceProvider _serviceProvider;
            private readonly IHttpContextAccessor _contextAccessor;

            public Provider(ServiceProvider serviceProvider)
            {
                _serviceProvider = serviceProvider;
                _contextAccessor = _serviceProvider.GetService<IHttpContextAccessor>();
            }

            public object GetService(Type serviceType)
            {
                return _contextAccessor?.HttpContext?.RequestServices.GetService(serviceType) ??
                       _serviceProvider.GetService(serviceType);
            }
        }
    }
}
