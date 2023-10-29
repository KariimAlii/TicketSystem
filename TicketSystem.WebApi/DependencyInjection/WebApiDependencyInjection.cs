using Microsoft.Extensions.Configuration;
using TicketSystem.Application.Contracts.Persistance.Context;
using TicketSystem.Application.DependencyInjection;
using TicketSystem.Persistance.Context;
using TicketSystem.Persistance.DependencyInjection;
using TicketSystem.Infrastructure.DependencyInjection;
using AutoMapper;
using System.Reflection;
using Microsoft.AspNetCore.Identity;
using TicketSystem.Domain.Entities;

namespace TicketSystem.WebApi.DependencyInjection
{
    public static class WebApiDependencyInjection
    {
        public static void AddWebApiLayerDependencyInjection(this IServiceCollection services, IConfiguration configuration)
        {
            AddPreLayers(services, configuration);
            AddDataBase(services, configuration);
            AddMapper(services);
        }
        private static void AddPreLayers(IServiceCollection services, IConfiguration configuration)
        {
            services.AddApplicationLayerDependencyInjection();
            services.AddInfrastructureLayerDependencyInjection(configuration);
        }
        private static void AddDataBase(IServiceCollection services, IConfiguration configuration)
        {
            services.AddPersistanceLayerDependencyInjection(configuration);
            services.AddScoped<ITicketAppDbContext, TicketAppDbContext>();
        }
        public static void AddMapper(IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
        }
        public static IServiceCollection AddCorsServices(this IServiceCollection services, string PolicyName)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(name: PolicyName, policy =>
                {
                    policy.AllowAnyOrigin()
                          .AllowAnyHeader()
                          .AllowAnyMethod();
                });
            });
            return services;
        }
        public static IServiceCollection AddIdentityServices(this IServiceCollection services)
        {
            services
                    .AddIdentity<User, IdentityRole>(options =>
                    {
                        options.Password.RequireUppercase = false;
                        options.Password.RequireLowercase = false;
                        options.Password.RequireNonAlphanumeric = false;
                        options.Password.RequiredLength = 5;

                        options.User.RequireUniqueEmail = true;

                        options.Lockout.MaxFailedAccessAttempts = 3;
                        options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(2);
                    })
                    .AddEntityFrameworkStores<TicketAppDbContext>();
            return services;
        }
    }
}
