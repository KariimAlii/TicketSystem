using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketSystem.Domain.Common;

namespace TicketSystem.Domain.Entities
{
    public class City : AuditableEntity
    {
        public string CityName { get; set; }
        public ICollection<Ticket> Tickets { get; set; } = new HashSet<Ticket>();
    }
}
