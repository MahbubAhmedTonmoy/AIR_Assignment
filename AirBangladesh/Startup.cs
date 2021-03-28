using AirBangladesh.DataContext;
using Application.Command;
using AutoMapper;
using Core.Entity;
using Core.Repository.Base;
using Infrastructure.Repository;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace AirBangladesh
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
            services.AddDbContext<AppDataContext>(options => 
                options.UseSqlServer(Configuration.GetConnectionString("DataBase")), ServiceLifetime.Transient)
                .AddIdentity<PassengerProfile, IdentityRole>(x => {
                    x.SignIn.RequireConfirmedEmail = true;
                }).AddDefaultTokenProviders().AddEntityFrameworkStores<AppDataContext>();

            services.AddControllers();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            // Add AutoMapper
            services.AddAutoMapper(typeof(Startup));

            // Add MediatR
            services.AddMediatR(typeof(FlightCreateCommand).GetTypeInfo().Assembly);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "AirBangladesh", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "AirBangladesh v1"));
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
