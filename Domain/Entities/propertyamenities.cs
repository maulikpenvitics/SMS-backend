using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
   
    public class PropertyAmenities : BaseAuditableEntity
    {
       
         /// <IsIdentity>True</IsIdentity>

        public int Id { get; set; }
        /// <IsColumn>True</IsColumn>
        /// <IsFilter>False</IsFilter>
        
        /// <IsJoin>Property</IsJoin>
        public int? PropertyId { get; set; }
        /// <IsColumn>True</IsColumn>
        /// <IsFilter>True</IsFilter>

        [StringLength(50)]
        public string Amenityname { get; set; }
        /// <IsColumn>True</IsColumn>
        /// <IsFilter>False</IsFilter>

        public int? Modifiedby { get; set; }
        /// <IsColumn>True</IsColumn>
        /// <IsFilter>False</IsFilter>

        public DateTime? ModifiedDate { get; set; }
       

       
    }
}
