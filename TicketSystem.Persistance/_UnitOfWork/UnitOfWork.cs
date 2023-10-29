using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketSystem.Application.Contracts.Persistance.Context;
using TicketSystem.Application.Contracts.Persistance.Repositories;
using TicketSystem.Application.Contracts.Persistance.UnitOfWork;
using TicketSystem.Domain.Entities;

namespace TicketSystem.Persistance._UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ITicketAppDbContext _context;

        public IGenericRepository<Governorate> _ticketRepo { get; }

        public IGenericRepository<District> _districtRepo { get; }

        public IGenericRepository<Governorate> _governorateRepo { get; }

        public IGenericRepository<City> _cityRepo { get; }

        public UnitOfWork
        (
            IGenericRepository<Governorate> ticketRepo,
            IGenericRepository<District> districtRepo,
            IGenericRepository<Governorate> governorateRepo,
            IGenericRepository<City> cityRepo,
            ITicketAppDbContext context
        )
        {
            _ticketRepo = ticketRepo;
            _districtRepo = districtRepo;
            _governorateRepo = governorateRepo;
            _cityRepo = cityRepo;
            _context = context;
        }
        public int DBSaveChanges()
        {
            return _context.DBSaveChanges();
        }

        public async Task<int> DBSaveChangesAsync()
        {
            return await _context.DBSaveChangesAsync();
        }
    }
}
