using Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class City : BaseAuditableEntity
    {
        /// <IsIdentity>True</IsIdentity> 
        public int Id { get; set; }
        /// <IsColumn>True</IsColumn>
        /// <IsFilter>True</IsFilter>
        public string Name { get; set; }
        /// <IsColumn>True</IsColumn>
        /// <IsFilter>False</IsFilter>
        /// 
        /// <IsJoin>State</IsJoin>
        public int StateId { get; set; }

    }
}