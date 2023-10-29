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
    public class GovernorateConfiguration : IEntityTypeConfiguration<Governorate>
    {
        public void Configure(EntityTypeBuilder<Governorate> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(b => b.Id)
            .ValueGeneratedOnAdd()
            .HasAnnotation("Sqlite:Autoincrement", true);

            builder.HasMany(a => a.Tickets)
                   .WithOne(b => b.Governorate)
                   .HasForeignKey(b => b.GovernorateId);
        }
    }
}
