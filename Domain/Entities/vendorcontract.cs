using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
  
    public class VendorContract : BaseAuditableEntity
    {
       
        ///<IsIdentity>True</IsIdentity>
        public int Id { get; set; }
        /// <IsColumn>True</IsColumn>
        /// <IsFilter>False</IsFilter>
        /// <IsJoin>vendor</IsJoin>
        public int? VendorId { get; set; }

        [StringLength(100)]
        /// <IsColumn>True</IsColumn>
        /// <IsFilter>False</IsFilter>
        public string Contracturl { get; set; }
        /// <IsColumn>True</IsColumn>
        /// <IsFilter>False</IsFilter>
        public DateTime? Fromdate { get; set; }
        /// <IsColumn>True</IsColumn>
        /// <IsFilter>False</IsFilter>
        public DateTime? Todate { get; set; }

       
        /// <IsColumn>True</IsColumn>
        /// <IsFilter>False</IsFilter>
        public decimal? Amount { get; set; }

        [StringLength(50)]
        /// <IsColumn>True</IsColumn>
        /// <IsFilter>False</IsFilter>
        public string Paymentcycle { get; set; }
        /// <IsColumn>True</IsColumn>
        /// <IsFilter>False</IsFilter>
        public int? Modifiedby { get; set; }
        /// <IsColumn>True</IsColumn>
        /// <IsFilter>False</IsFilter>
        public DateTime? Modifieddate { get; set; }
    }
}
