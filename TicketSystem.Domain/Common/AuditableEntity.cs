using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketSystem.Domain.Entities;

namespace TicketSystem.Domain.Common
{
    public class AuditableEntity
    {
        [Key]
        public int Id { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? LastModifiedDate { get; set; }

        #region Foreign Keys
        public string? CreatedById { get; set; }
        public string? LastModifiedById { get; set; } 
        #endregion

        #region Navigation Properties
        public User CreatedBy { get; set; }
        public User LastModifiedBy { get; set; } 
        #endregion
    }
}
