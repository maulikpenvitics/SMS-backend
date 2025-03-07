using Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Category : BaseAuditableEntity
    {
        [Key]
        /// <IsIdentity>True</IsIdentity> 
        public int Id { get; set; }
        /// <IsColumn>True</IsColumn>
        /// <IsFilter>True</IsFilter>
        public string Name { get; set; }
        /// <IsColumn>False</IsColumn>
        /// <IsFilter>False</IsFilter>
        public int? CreatedBy { get; set; }
        /// <IsColumn>False</IsColumn>
        /// <IsFilter>False</IsFilter>
        public int? ModifiedBy { get; set; }
        /// <IsColumn>False</IsColumn>
        /// <IsFilter>False</IsFilter>
        public DateTime? CreatedDate { get; set; }
        /// <IsColumn>False</IsColumn>
        /// <IsFilter>False</IsFilter>
        public DateTime? ModifiedDate { get; set; }
        /// <IsColumn>False</IsColumn>
        /// <IsFilter>False</IsFilter>
        public bool IsActive { get; set; }
        /// <IsColumn>False</IsColumn>
        /// <IsFilter>False</IsFilter>
        public bool IsDeleted { get; set; }
    }
}
