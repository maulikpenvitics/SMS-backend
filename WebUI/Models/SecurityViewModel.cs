// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Collections.Generic;
using Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
 using Data.Residents;
 using Data.Users;
 using Data.Vendors;
 using Data.Securitys;


namespace WebUI.Models
{
          public class SecurityViewModel
          {
                public int Id {get;set;}
public int? ResidentId {get;set;}
public int? UserId {get;set;}
public int? VendorId {get;set;}
public string Incidence {get;set;}
public string Securitydesc {get;set;}
public int? Modifiedby {get;set;}
public System.DateTime? Modifieddate {get;set;}

                 public List<SelectListItem> DropdownResident { get; set; }
 public List<SelectListItem> DropdownUser { get; set; }
 public List<SelectListItem> DropdownVendor { get; set; }

                
          }
        public class SecurityListViewModel
        {
            public List<SecurityResponseModel> List { get; set; }
              public List<SelectListItem> DropdownResident { get; set; }
 public List<SelectListItem> DropdownUser { get; set; }
 public List<SelectListItem> DropdownVendor { get; set; }

             
           
        }
        public class SecurityFilter
        {
            
            public bool FilterSwitch { get; set; }
        }
}
   


