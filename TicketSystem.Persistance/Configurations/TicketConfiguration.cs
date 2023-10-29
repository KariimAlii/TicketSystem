using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketSystem.Domain.Entities;

namespace TicketSystem.Persistance.Configurations
{
    public class TicketConfiguration : IEntityTypeConfiguration<Ticket>
    {
        public void Configure(EntityTypeBuilder<Ticket> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(b => b.Id)
            .ValueGeneratedOnAdd()
            .HasAnnotation("Sqlite:Autoincrement", true);

            builder.HasOne(b => b.City)
                   .WithMany(a => a.Tickets)
                   .HasForeignKey(b => b.CityId);

            builder.HasOne(b => b.District)
                   .WithMany(a => a.Tickets)
                   .HasForeignKey(b => b.DistrictId);

            builder.HasOne(b => b.Governorate)
                   .WithMany(a => a.Tickets)
                   .HasForeignKey(b => b.GovernorateId);
        }
    }
}
