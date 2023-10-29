using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TicketSystem.Application.Contracts.Persistance.Context;
using TicketSystem.Domain.Common;
using TicketSystem.Domain.Entities;
using TicketSystem.Persistance.SeedingData;

namespace TicketSystem.Persistance.Context
{
    public partial class TicketAppDbContext : IdentityDbContext<User>, ITicketAppDbContext
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        //private readonly UserManager<User> _userManager;
        public DbSet<Governorate> Governorates { get; set; }
        public DbSet<District> Districts { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Governorate> Tickets { get; set; }
        public TicketAppDbContext()
        {
            
        }
        public TicketAppDbContext(DbContextOptions<TicketAppDbContext> options ) : base(options) //, IHttpContextAccessor httpContextAccessor , UserManager<User> userManager
        {
            //_httpContextAccessor = httpContextAccessor;
            //_userManager = userManager;
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlite("Data Source=TicketSystemDB.db");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TicketAppDbContext).Assembly);
            modelBuilder.SeedGovernorateData();
            modelBuilder.SeedDistrictData();
            modelBuilder.SeedCityData();
            modelBuilder.SeedTicketData();
            base.OnModelCreating(modelBuilder);
        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            //var httpContext = _httpContextAccessor.HttpContext;

            //if (httpContext != null && httpContext.User.Identity.IsAuthenticated)
            //{
                //var currentUserId = httpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

                foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
                {
                    switch (entry.State)
                    {
                        case EntityState.Added:
                            //entry.Entity.CreatedById = currentUserId;
                            entry.Entity.CreatedDate = DateTime.Now;
                            break;
                        case EntityState.Modified:
                            //entry.Entity.LastModifiedById = currentUserId;
                            entry.Entity.LastModifiedDate = DateTime.Now;
                            break;
                    }
                }
            //}

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
