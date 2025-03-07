// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Collections.Generic;
using Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
 using Data.Propertys;
 using Data.Blocks;
using Data.Units;
 using Data.Residents;


namespace WebUI.Models
{
    public class ResidentViewModel
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Phoneno { get; set; }
        public string Detailedinfo { get; set; }
        public int? PropertyId { get; set; }
        public int? BlockId { get; set; }
        public int? UnitId { get; set; }
        public int? Modifiedby { get; set; }
        public System.DateTime? Modifieddate { get; set; }

        public List<SelectListItem> DropdownProperty { get; set; }
        public List<SelectListItem> DropdownBlock { get; set; }

        public List<SelectListItem> DropdownUnit { get; set; }


    }
    public class ResidentListViewModel
    {
        public List<ResidentResponseModel> List { get; set; }
        public List<SelectListItem> DropdownProperty { get; set; }
        public List<SelectListItem> DropdownBlock { get; set; }
        public List<SelectListItem> DropdownUnit { get; set; }



    }
    public class ResidentFilter
    {
     public string ResidentPassword {get;set;}
    public string ResidentPhoneno { get; set; }

    public bool FilterSwitch { get; set; }
        }
}
   


