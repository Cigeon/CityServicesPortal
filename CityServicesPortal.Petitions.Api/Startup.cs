﻿using AutoMapper;
using CityServicesPortal.Petitions.Infra.IoC;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace CityServicesPortal.Petitions.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //string connection = Configuration.GetConnectionString("DefaultConnection");
            //services.AddDbContext<PetitionsContext>(options =>
            //    options.UseSqlServer(connection));

            services.AddAutoMapper();

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(o =>
            {
                o.Authority = Configuration["IdentityServerAddress"];
                o.Audience = "petitionsApi";
                o.RequireHttpsMetadata = false;
            });

            services.AddCors(options =>
            {
                options.AddPolicy("default", policy =>
                {
                    policy.WithOrigins(Configuration["ClientAddress"])
                        .WithOrigins(Configuration["PetitionsClientAddress"])
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
            });

            // Register the Swagger generator, defining one or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Petitions API", Version = "v1" });
            });

            // Adding MediatR for Domain Events and Notifications
            services.AddMediatR(typeof(Startup));

            // .NET Native DI Abstraction
            RegisterServices(services);

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("default");

            app.UseAuthentication();            

            app.UseMvc();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Petitions API V1");
            });
        }

        private static void RegisterServices(IServiceCollection services)
        {
            // Adding dependencies from another layers
            NativeInjectorBootStrapper.RegisterServices(services);
        }
    }
}
