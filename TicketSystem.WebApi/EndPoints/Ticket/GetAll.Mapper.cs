using AutoMapper;
using TicketSystem.Application.Features.Tickets.Queries.GetAllTickets;

namespace TicketSystem.WebApi.EndPoints.Ticket
{
    public class GetAllMapper : Profile
    {
        public GetAllMapper()
        {
            CreateMap<GetAllRequest, GetAllTicketsQuery>();
        }
    }
}
