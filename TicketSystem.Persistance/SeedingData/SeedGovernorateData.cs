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
        public static void SeedGovernorateData(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Governorate>().HasData(
                new Governorate { Id = 1, GovernorateName = "Giza" },
                new Governorate { Id = 2, GovernorateName = "Cairo" },
                new Governorate { Id = 3, GovernorateName = "Cairo" }
            );
        }
    }
}
