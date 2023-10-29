using MediatR;
using TicketSystem.Application.Features.Tickets.Commands.CreateTicket;
using TicketSystem.Application.Features.Tickets.Queries.GetAllTickets;
using TicketSystem.WebApi.Responses;

namespace TicketSystem.WebApi.EndPoints.Ticket
{
    public class HandleResponse : BaseResponse
    {
        public Unit Result { get; set; }
    }
}
