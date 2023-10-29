using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketSystem.Domain.Entities;

namespace TicketSystem.Application.Features.Tickets.Queries.GetAllTickets
{
    public class GetAllTicketsQueryModel
    {
        public int Id { get; set; }
        public string PhoneNumber { get; set; }
        public string Status { get; set; }

        public int GovernorateId { get; set; }
        public int DistrictId { get; set; }
        public int CityId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? LastModifiedDate { get; set; }

    }
}
