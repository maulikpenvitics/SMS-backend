using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    
    public class User : BaseAuditableEntity
    {
        
        ///<IsIdentity>True</IsIdentity>
        public int Id { get; set; }

        [StringLength(30)]
        /// <IsColumn>True</IsColumn>
        /// <IsFilter>True</IsFilter>
        public string Username { get; set; }
        /// <IsColumn>True</IsColumn>
        /// <IsFilter>True</IsFilter>
        public string Password { get; set; }

        [StringLength(50)]
        /// <IsColumn>True</IsColumn>
        /// <IsFilter>True</IsFilter>
        public string Firstname { get; set; }

        [StringLength(20)]
        /// <IsColumn>True</IsColumn>
        /// <IsFilter>True</IsFilter>
        public string Lastname { get; set; }

        [StringLength(50)]
        /// <IsColumn>True</IsColumn>
        /// <IsFilter>True</IsFilter>
        public string Email { get; set; }
        /// <IsColumn>True</IsColumn>
        /// <IsFilter>True</IsFilter>
        public string Phone { get; set; }
        /// <IsColumn>True</IsColumn>
        /// <IsFilter>False</IsFilter>
        /// <IsJoin>property</IsJoin>
        public int? PropertyId { get; set; }
        /// <IsColumn>True</IsColumn>
        /// <IsFilter>False</IsFilter>
        /// <IsJoin>role</IsJoin>
        public int? RoleId { get; set; }
        /// <IsColumn>True</IsColumn>
        /// <IsFilter>False</IsFilter>
        public int? Modifiedby { get; set; }
        /// <IsColumn>True</IsColumn>
        /// <IsFilter>False</IsFilter>
        public DateTime? Modifieddate { get; set; }
    }
}
