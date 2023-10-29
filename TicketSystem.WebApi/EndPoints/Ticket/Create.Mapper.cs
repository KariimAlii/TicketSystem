using AutoMapper;
using TicketSystem.Application.Features.Tickets.Commands.CreateTicket;

namespace TicketSystem.WebApi.EndPoints.Ticket
{
    public class CreateMapper : Profile
    {
        public CreateMapper()
        {
            CreateMap<CreateRequest, CreateTicketCommand>().ReverseMap();
        }
    }
}
