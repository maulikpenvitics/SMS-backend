using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Unit : BaseAuditableEntity
    {
        [Key]
        /// <IsIdentity>True</IsIdentity>
        public int Id { get; set; }

        /// <IsColumn>True</IsColumn>
        /// <IsFilter>True</IsFilter>
        [StringLength(50)]
        public string Unitname { get; set; }

        /// <IsColumn>True</IsColumn>
        /// <IsFilter>False</IsFilter>
        /// <IsJoin>Block</IsJoin>
        public int? BlockId { get; set; }
    }
}
