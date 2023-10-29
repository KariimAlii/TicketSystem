using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketSystem.Application.Features.Tickets.Commands.CreateTicket;
using TicketSystem.Domain.Entities;

namespace TicketSystem.Application.Features.Tickets.Commands.HandleTicket
{
    public class HandleTicketCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public string Status { get; set; }
        public DateTime? LastModifiedDate { get; set; }

        public override string ToString()
        {
            return $"A Ticket was handled  ==> Id : {Id} , Status : {Status} ";
        }
    }
}
