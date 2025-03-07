using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace WebUI.Models
{
    public class OwnerViewModel
    {
        public int Id { get; set; }

        public string Blockname { get; set; }
        public string Unitname { get; set; }

        public string Residentname { get; set; }
      

        

        [Required]
        public string Firstname { get; set; }

        [Required]
        public string Lastname { get; set; }

        public int? PropertyId { get; set; }
        public int? BlockId { get; set; }
        public int? UnitId { get; set; }

        public int? Modifiedby { get; set; }
        public DateTime? Modifieddate { get; set; }

        public List<SelectListItem> DropdownProperty { get; set; }
        public List<SelectListItem> DropdownBlock { get; set; }
        public List<SelectListItem> DropdownUnit { get; set; }
    }

      

    
}
