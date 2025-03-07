using Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Role : BaseAuditableEntity
    {
        /// <IsIdentity>True</IsIdentity> 
        public int Id { get; set; }
        /// <IsColumn>True</IsColumn>
        /// <IsFilter>False</IsFilter>
        public string Name { get; set; }
        /// <IsColumn>False</IsColumn>
        /// <IsFilter>False</IsFilter>
        public int? ModifiedBy { get; set; }
        /// <IsColumn>False</IsColumn>
        /// <IsFilter>False</IsFilter>
        public DateTime? ModifiedDate { get; set; }
      
    }
}
