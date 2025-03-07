using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
   
    public class PropertyOwners : BaseAuditableEntity
    {
     
        /// <IsIdentity>True</IsIdentity>
        public int Id { get; set; }
        /// <IsColumn>True</IsColumn>
        /// <IsFilter>True</IsFilter>

        [StringLength(50)]
        public string Firstname { get; set; }
        /// <IsColumn>True</IsColumn>
        /// <IsFilter>True</IsFilter>

        [StringLength(50)]
        public string Lastname { get; set; }
        /// <IsColumn>True</IsColumn>
        /// <IsFilter>False</IsFilter>

        [StringLength(50)]
        public string Email { get; set; }
        /// <IsColumn>True</IsColumn>
        /// <IsFilter>False</IsFilter>

        public string Phoneno { get; set; }
        /// <IsColumn>True</IsColumn>
        /// <IsFilter>False</IsFilter>

        /// <IsJoin>Block<IsJoin>
        public int? BlockId { get; set; }
        /// <IsColumn>True</IsColumn>
        /// <IsFilter>False</IsFilter>

        public int? Modifiedby { get; set; }
        /// <IsColumn>True</IsColumn>
        /// <IsFilter>False</IsFilter>

        public DateTime? Modifieddate { get; set; }
        
    }
}
