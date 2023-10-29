using MediatR;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TicketSystem.Application.Features.Tickets.Commands.CreateTicket
{
    public class CreateTicketCommand : IRequest<CreateTicketCommandModel>
    {
        public int Id { get; set; }
        public string Status { get; set; }
        public string PhoneNumber { get; set; }
        public int GovernorateId { get; set; }
        public int DistrictId { get; set; }
        public int CityId { get; set; }
        public override string ToString()
        {
            return $"Ticket Information ==> Status : {Status} , GovernorateId : {GovernorateId} , DistrictId : {DistrictId} , CityId : {CityId} ";
        }
    }
}
