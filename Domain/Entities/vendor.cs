using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
   
    public class Vendor : BaseAuditableEntity
    {
       
        ///<IsIdentity>True</IsIdentity>
        public int Id { get; set; }
        /// <IsColumn>True</IsColumn>
        /// <IsFilter>True</IsFilter>
        public string Firstname { get; set; }
        /// <IsColumn>True</IsColumn>
        /// <IsFilter>True</IsFilter>
        public string Lastname { get; set; }
        /// <IsColumn>True</IsColumn>
        /// <IsFilter>True</IsFilter>
        public string Companyname { get; set; }
        /// <IsColumn>True</IsColumn>
        /// <IsFilter>False</IsFilter>
        public string Address1 { get; set; }
        /// <IsColumn>True</IsColumn>
        /// <IsFilter>False</IsFilter>
        public string Address2 { get; set; }
        /// <IsColumn>True</IsColumn>
        /// <IsFilter>False</IsFilter>
        /// <IsJoin>City</IsJoin>
        public int? Cityid { get; set; }
        /// <IsColumn>True</IsColumn>
        /// <IsFilter>False</IsFilter>
        /// <IsJoin>State</IsJoin>
        public int? Stateid { get; set; }
        /// <IsColumn>True</IsColumn>
        /// <IsFilter>False</IsFilter>
        /// <IsJoin>Country</IsJoin>
        public int? Countryid { get; set; }
        /// <IsColumn>True</IsColumn>
        /// <IsFilter>False</IsFilter>
        public int? ModifiedBy { get; set; }
        /// <IsColumn>True</IsColumn>
        /// <IsFilter>False</IsFilter>
        public DateTime? ModifiedDate { get; set; }
    }
}
