using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketSystem.Domain.Entities;

namespace TicketSystem.Application.Contracts.Persistance.Context
{
    public interface ITicketAppDbContext
    {
        #region Methods
        int DBSaveChanges();
        Task<int> DBSaveChangesAsync(CancellationToken cancellationToken = default);
        #endregion

        #region DB Sets
        DbSet<Governorate> Governorates { get; set; }
        DbSet<District> Districts { get; set; }
        DbSet<City> Cities { get; set; }
        DbSet<Governorate> Tickets { get; set; }
        #endregion
    }
}
