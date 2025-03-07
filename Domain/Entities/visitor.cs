using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
   
    public class Visitor:BaseAuditableEntity
    {
      
        ///<IsIdentity>True</IsIdentity>
        public int Id { get; set; }

        [StringLength(50)]
        /// <IsColumn>True</IsColumn>
        /// <IsFilter>True</IsFilter>
        public string Firstname { get; set; }

        [StringLength(30)]
        /// <IsColumn>True</IsColumn>
        /// <IsFilter>True</IsFilter>
        public string Lastname { get; set; }
        /// <IsColumn>True</IsColumn>
        /// <IsFilter>True</IsFilter>
        public int? Idno { get; set; }

        [StringLength(20)]
        /// <IsColumn>True</IsColumn>
        /// <IsFilter>True</IsFilter>
        public string Idtype { get; set; }
        /// <IsColumn>True</IsColumn>
        /// <IsFilter>True</IsFilter>
        public int? Gatepass { get; set; }
        /// <IsColumn>True</IsColumn>
        /// <IsFilter>True</IsFilter>
        public string Phoneno { get; set; }
        /// <IsColumn>True</IsColumn>
        /// <IsFilter>False</IsFilter>
        public int? Modifiedby { get; set; }
        /// <IsColumn>True</IsColumn>
        /// <IsFilter>False</IsFilter>
        public DateTime? Modifieddate { get; set; }
    }
}
