using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketSystem.Application.Contracts.Persistance.Repositories;
using TicketSystem.Domain.Entities;

namespace TicketSystem.Application.Features.Tickets.Queries.GetAllTickets
{
    public class GetAllTicketsQueryHandler : IRequestHandler<GetAllTicketsQuery, List<GetAllTicketsQueryModel>>
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<Ticket> _ticketRepository;

        public GetAllTicketsQueryHandler(IMapper mapper , IGenericRepository<Ticket> ticketRepository)
        {
            _mapper = mapper;
            _ticketRepository = ticketRepository;
        }
        public async Task<List<GetAllTicketsQueryModel>> Handle(GetAllTicketsQuery request, CancellationToken cancellationToken)
        {

            try
            {
                List<Ticket> AllTickets = await _ticketRepository.ListAllAsync(null, request.Page, request.PageSize);
                List<GetAllTicketsQueryModel> dataModelList = _mapper.Map<List<GetAllTicketsQueryModel>>(AllTickets);
                return dataModelList;
            }
            catch (Exception ex)
            {
                return default;
            }

        }
    }
}
