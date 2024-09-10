using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketSystem.Application.Contracts.Persistance.Repositories;
using TicketSystem.Application.Contracts.Persistance.UnitOfWork;
using TicketSystem.Domain.Entities;
using TicketSystem.Persistance._UnitOfWork;
using TicketSystem.Persistance.Context;
using TicketSystem.Persistance.Repositories;

namespace TicketSystem.Persistance.DependencyInjection
{
    public static class PersistanceDependencyInjection
    {
        public static IServiceCollection AddPersistanceLayerDependencyInjection(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHttpContextAccessor();

            services.AddDbContext<TicketAppDbContext>(optionsBuilder =>
            {
                string LocalConnectionString = configuration.GetConnectionString("LocalConnectionString");
                optionsBuilder.UseSqlServer(LocalConnectionString);
            });

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
