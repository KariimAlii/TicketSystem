using AutoMapper;
using TicketSystem.Application.Features.Tickets.Commands.CreateTicket;
using TicketSystem.Application.Features.Tickets.Commands.HandleTicket;

namespace TicketSystem.WebApi.EndPoints.Ticket
{
    public class HandleMapper : Profile
    {
        public HandleMapper()
        {
            CreateMap<HandleRequest, HandleTicketCommand>().ReverseMap();
        }
    }
}
