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
        public static void SeedTicketData(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ticket>().HasData(
                new Ticket { Id = 1, GovernorateId = 1, DistrictId = 1, CityId = 1, PhoneNumber = "01222868979" , Status = "UnHandled" , CreatedDate = DateTime.Now , LastModifiedDate = DateTime.Now},
                new Ticket { Id = 2, GovernorateId = 2, DistrictId = 2, CityId = 2, PhoneNumber = "01062065789" , Status = "UnHandled" , CreatedDate = DateTime.Now, LastModifiedDate = DateTime.Now },
                new Ticket { Id = 3, GovernorateId = 3, DistrictId = 3, CityId = 3, PhoneNumber = "01124464869" , Status = "UnHandled" , CreatedDate = DateTime.Now , LastModifiedDate = DateTime.Now},
                new Ticket { Id = 4, GovernorateId = 3, DistrictId = 3, CityId = 3, PhoneNumber = "01124464869" , Status = "UnHandled"  , CreatedDate = DateTime.Now, LastModifiedDate = DateTime.Now },
                new Ticket { Id = 6, GovernorateId = 3, DistrictId = 3, CityId = 3, PhoneNumber = "01124464869" , Status = "UnHandled" , CreatedDate = DateTime.Now, LastModifiedDate = DateTime.Now },
                new Ticket { Id = 7, GovernorateId = 3, DistrictId = 3, CityId = 3, PhoneNumber = "01124464869" , Status = "UnHandled" , CreatedDate = DateTime.Now , LastModifiedDate = DateTime.Now},
                new Ticket { Id = 8, GovernorateId = 3, DistrictId = 3, CityId = 3, PhoneNumber = "01124464869" , Status = "UnHandled"  , CreatedDate = DateTime.Now, LastModifiedDate = DateTime.Now},
                new Ticket { Id = 9, GovernorateId = 3, DistrictId = 3, CityId = 3, PhoneNumber = "01124464869" , Status = "UnHandled"  , CreatedDate = DateTime.Now, LastModifiedDate = DateTime.Now},
                new Ticket { Id = 10, GovernorateId = 3, DistrictId = 3, CityId = 3, PhoneNumber = "01124464869" , Status = "UnHandled" , CreatedDate = DateTime.Now , LastModifiedDate = DateTime.Now},
                new Ticket { Id = 11, GovernorateId = 3, DistrictId = 3, CityId = 3, PhoneNumber = "01124464869" , Status = "UnHandled" , CreatedDate = DateTime.Now , LastModifiedDate = DateTime.Now},
                new Ticket { Id = 12, GovernorateId = 3, DistrictId = 3, CityId = 3, PhoneNumber = "01124464869" , Status = "UnHandled" , CreatedDate = DateTime.Now , LastModifiedDate = DateTime.Now}
            );
        }
    }
}
