using TicketSystem.Application.Features.Tickets.Queries.GetAllTickets;
using TicketSystem.WebApi.Responses;

namespace TicketSystem.WebApi.EndPoints.Ticket
{
    public class GetAllResponse : BaseResponse
    {
        public List<GetAllTicketsQueryModel> Result { get; set; }
    }
}
