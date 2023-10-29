using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketSystem.Application.Features.Tickets.Queries.GetAllTickets
{
    public class GetAllTicketsQuery : IRequest<List<GetAllTicketsQueryModel>>
    {
        public int PageSize { get; set; }
        public int Page { get; set; }
    }
}
