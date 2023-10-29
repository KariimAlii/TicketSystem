using AutoMapper;
using TicketSystem.Application.Features.Tickets.Commands.CreateTicket;
using TicketSystem.Application.Features.Tickets.Queries.GetAllTickets;
using TicketSystem.Domain.Entities;

namespace TicketSystem.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Ticket, GetAllTicketsQueryModel>().ReverseMap();
            CreateMap<CreateTicketCommand,Ticket>().ReverseMap();
            CreateMap<Ticket, CreateTicketCommandModel>().ReverseMap();
        }
    }
}
