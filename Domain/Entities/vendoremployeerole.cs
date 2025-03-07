using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
  
    public class VendorEmployeeRole : BaseAuditableEntity
    {
      
        ///<IsIdentity>True</IsIdentity>
        public int Id { get; set; }

        [StringLength(50)]
        /// <IsColumn>True</IsColumn>
        /// <IsFilter>True</IsFilter>
        public string Name { get; set; }
        /// <IsColumn>True</IsColumn>
        /// <IsFilter>False</IsFilter>
        public int? Modifiedby { get; set; }
        /// <IsColumn>True</IsColumn>
        /// <IsFilter>False</IsFilter>
        public DateTime? Modifieddate { get; set; }
    }
}
