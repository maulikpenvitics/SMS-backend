using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
   
    public class PropertyRenteeAgreement : BaseAuditableEntity
    {
      
        /// <IsIdentity>True</IsIdentity>
        public int Id { get; set; }
        /// <IsColumn>True</IsColumn>
        /// <IsFilter>False</IsFilter>


        public int? PropertyId { get; set; }
        /// <IsColumn>True</IsColumn>
        /// <IsFilter>False</IsFilter>

        /// <IsJoin>Block<IsJoin>
        public int? BlockId { get; set; }
        /// <IsColumn>True</IsColumn>
        /// <IsFilter>False</IsFilter>


        public int? Unitid { get; set; }
        /// <IsColumn>True</IsColumn>
        /// <IsFilter>False</IsFilter>


        [StringLength(50)]
        public string Agreementurl { get; set; }
        /// <IsColumn>True</IsColumn>
        /// <IsFilter>False</IsFilter>

        /// <IsJoin>PropertyRentee</IsJoin>
        public int? PropertyRenteeId { get; set; }
        /// <IsColumn>True</IsColumn>
        /// <IsFilter>False</IsFilter>


        public DateTime? Agreementstartdate { get; set; }
        /// <IsColumn>True</IsColumn>
        /// <IsFilter>False</IsFilter>


        public DateTime? Agreementenddate { get; set; }
        /// <IsColumn>True</IsColumn>
        /// <IsFilter>False</IsFilter>


        public int? Modifiedby { get; set; }
        /// <IsColumn>True</IsColumn>
        /// <IsFilter>False</IsFilter>


        public DateTime? Modifieddate { get; set; }
        /// <IsColumn>True</IsColumn>
        /// <IsFilter>False</IsFilter>


    }
}
