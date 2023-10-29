using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketSystem.Domain.Common;

namespace TicketSystem.Domain.Entities
{
    public class Ticket : AuditableEntity
    {
        public string PhoneNumber { get; set; }

        public string Status { get; set; }

        #region Foreign Keys
        public int GovernorateId { get; set; }
        public int DistrictId { get; set; }
        public int CityId { get; set; }
        #endregion

        #region Navigation Properties

        [ForeignKey("GovernorateId")]
        public virtual Governorate Governorate { get; set; }


        [ForeignKey("DistrictId")]
        public virtual District District { get; set; }



        [ForeignKey("CityId")]
        public virtual City City { get; set; }

        #endregion

    }
}
