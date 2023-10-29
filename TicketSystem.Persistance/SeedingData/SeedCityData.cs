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
        public static void SeedCityData(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<City>().HasData(
                new City { Id = 1 , CityName = "6 October" },
                new City { Id = 2,  CityName = "Masr El Gadida" },
                new City { Id = 3,  CityName = "New Cairo" }
            );
        }
    }
}
