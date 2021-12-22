﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FoodApi.Data;

namespace FoodApi
{
    public class Startup
    {
        private const string APIKEYNAME = "ApiKey";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();

            services.AddDbContext<FoodApiContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("FoodApiContext"));
                options.EnableSensitiveDataLogging();
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "FoodApi",
                    Version = "v1",
                    Description = "FApi for food products",
                    Contact = new OpenApiContact { Name = "MJ", Email = "maksymilianjachymczak@gmail.com" },
                    License = new OpenApiLicense { Name = "GitHub", Url = new System.Uri("https://github.com/MvxJ/ASP.net-Application") }
                });

                c.AddSecurityDefinition(APIKEYNAME, new OpenApiSecurityScheme()
                {
                    In = ParameterLocation.Header,
                    Name = APIKEYNAME,
                    Type = SecuritySchemeType.ApiKey,
                    Description = "Prosze podać zakupiony klucz do API."
                });

                var key = new OpenApiSecurityScheme()
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = APIKEYNAME
                    },
                    In = ParameterLocation.Header
                };

                var requirement = new OpenApiSecurityRequirement
                    { { key, new List<string>() }};

                c.AddSecurityRequirement(requirement);
            });

            services.AddDbContext<FoodApiContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("FoodApiContext")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "FoodApi v1"));
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
