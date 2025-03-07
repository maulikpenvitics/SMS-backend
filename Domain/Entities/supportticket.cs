using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    
    public class SupportTicket : BaseAuditableEntity
    {
     
        /// <IsIdentity>True</IsIdentity>
        public int Id { get; set; }
        /// <IsColumn>True</IsColumn>
        /// <IsFilter>False</IsFilter>
        /// 
        ///<IsJoin>User</IsJoin>
        public int? UserId { get; set; }

        [StringLength(50)]
        /// <IsColumn>True</IsColumn>
        /// <IsFilter>True</IsFilter>
        public string Ticket { get; set; }

        [StringLength(100)]
        /// <IsColumn>True</IsColumn>
        /// <IsFilter>True</IsFilter>
        public string Description { get; set; }

        [StringLength(50)]
        /// <IsColumn>True</IsColumn>
        /// <IsFilter>False</IsFilter>
        public string Severity { get; set; }
        /// <IsColumn>True</IsColumn>
        /// <IsFilter>False</IsFilter>
        public string Duedate { get; set; }
        /// <IsColumn>True</IsColumn>
        /// <IsFilter>False</IsFilter>
        /// 
        ///<IsJoin>service</IsJoin>
        public int? ServiceId { get; set; }

        [StringLength(20)]
        /// <IsColumn>True</IsColumn>
        /// <IsFilter>False</IsFilter>
        public string Status { get; set; }

        [StringLength(100)]
        /// <IsColumn>True</IsColumn>
        /// <IsFilter>False</IsFilter>
        public string Comment { get; set; }
        /// <IsColumn>True</IsColumn>
        /// <IsFilter>False</IsFilter>
        public int? VendorEmployeeId { get; set; }
        /// <IsColumn>True</IsColumn>
        /// <IsFilter>False</IsFilter>
        /// 
        ///<IsJoin>vendor</IsJoin>
        public int? VendorId { get; set; }
        /// <IsColumn>True</IsColumn>
        /// <IsFilter>False</IsFilter>
        public int? Modifiedby { get; set; }
        /// <IsColumn>True</IsColumn>
        /// <IsFilter>False</IsFilter>
        public DateTime? Modifieddate { get; set; }
    }
}
