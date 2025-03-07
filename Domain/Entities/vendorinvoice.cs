using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
  
    public class VendorInvoice : BaseAuditableEntity
    {
        
        ///<IsIdentity>True</IsIdentity>
        public int Id { get; set; }
        /// <IsColumn>True</IsColumn>
        /// <IsFilter>False</IsFilter>
        /// <IsJoin>vendor</IsJoin>
        public int? VendorId { get; set; }
        /// <IsColumn>True</IsColumn>
        /// <IsFilter>False</IsFilter>
        public DateTime? Invoicedate { get; set; }
        /// <IsColumn>True</IsColumn>
        /// <IsFilter>False</IsFilter>
        public DateTime? Todate { get; set; }
        /// <IsColumn>True</IsColumn>
        /// <IsFilter>False</IsFilter>
       
        /// <IsColumn>True</IsColumn>
        /// <IsFilter>False</IsFilter>
        public decimal? Amount { get; set; }
        /// <IsColumn>True</IsColumn>
        /// <IsFilter>False</IsFilter>
        public DateTime? Duedate { get; set; }

       
        /// <IsColumn>True</IsColumn>
        /// <IsFilter>False</IsFilter>
        public decimal? Tax { get; set; }

      
        /// <IsColumn>True</IsColumn>
        /// <IsFilter>False</IsFilter>
        public decimal? NetAmount { get; set; }
        /// <IsColumn>True</IsColumn>
        /// <IsFilter>False</IsFilter>
        public int? Modifiedby { get; set; }
        /// <IsColumn>True</IsColumn>
        /// <IsFilter>False</IsFilter>
        public DateTime? Modifieddate { get; set; }

       
    }
}
