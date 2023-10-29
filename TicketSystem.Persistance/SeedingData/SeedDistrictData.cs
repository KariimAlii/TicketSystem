using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketSystem.Domain.Entities;

namespace TicketSystem.Persistance.SeedingData
{
    public static partial class ModelBuilderExtensions
    {
        public static void SeedDistrictData(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<District>().HasData(
                new District { Id = 1, DistrictName = "Sheikh Zayed" },
                new District { Id = 2, DistrictName = "El Mohandeseen" },
                new District { Id = 3, DistrictName = "Maadi" }
            );
        }
    }
}
