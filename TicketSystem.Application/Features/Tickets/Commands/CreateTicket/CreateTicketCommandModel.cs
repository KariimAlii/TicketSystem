using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketSystem.Domain.Entities;

namespace TicketSystem.Application.Features.Tickets.Commands.CreateTicket
{
    public class CreateTicketCommandModel
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public string? CreatedById { get; set; }
        public string? LastModifiedById { get; set; }
        public string Status { get; set; }
        public string PhoneNumber { get; set; }
        public int GovernorateId { get; set; }
        public int DistrictId { get; set; }
        public int CityId { get; set; }
    }
}
