using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class DropdownItem
    {
        /// <IsIdentity>True</IsIdentity>
        public int Id { get; set; }
        /// <IsColumn>True</IsColumn>
        /// <IsFilter>True</IsFilter>
        public string Name { get; set; }
    }
}
