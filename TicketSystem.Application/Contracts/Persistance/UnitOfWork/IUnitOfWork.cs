using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketSystem.Application.Contracts.Persistance.Context;
using TicketSystem.Application.Contracts.Persistance.Repositories;
using TicketSystem.Domain.Entities;

namespace TicketSystem.Application.Contracts.Persistance.UnitOfWork
{
    public interface IUnitOfWork
    {
        IGenericRepository<Governorate> _ticketRepo { get; }
        IGenericRepository<District> _districtRepo { get; }
        IGenericRepository<Governorate> _governorateRepo { get; }
        IGenericRepository<City> _cityRepo { get; }
        int DBSaveChanges();
        Task<int> DBSaveChangesAsync();
    }
}
