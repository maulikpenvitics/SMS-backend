using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
   
    public class VendorInvoiceDetail : BaseAuditableEntity
    {
      
        ///<IsIdentity>True</IsIdentity>
        public int Id { get; set; }
        /// <IsColumn>True</IsColumn>
        /// <IsFilter>False</IsFilter>
        public int? VendorInvoiceId { get; set; }

        [StringLength(20)]
        /// <IsColumn>True</IsColumn>
        /// <IsFilter>False</IsFilter>
        public string Lineitem { get; set; }

      
        /// <IsColumn>True</IsColumn>
        /// <IsFilter>False</IsFilter>
        public decimal? Amount { get; set; }

        [StringLength(100)]
        /// <IsColumn>True</IsColumn>
        /// <IsFilter>False</IsFilter>
        public string Description { get; set; }
        /// <IsColumn>True</IsColumn>
        /// <IsFilter>False</IsFilter>
        public int? Modifiedby { get; set; }
        /// <IsColumn>True</IsColumn>
        /// <IsFilter>False</IsFilter>
        public DateTime? Modifieddate { get; set; }

     
    }
}
