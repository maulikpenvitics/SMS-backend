// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Collections.Generic;
using Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
 using Data.Vendors;
 using Data.Services;
 using Data.VendorServices;


namespace WebUI.Models
{
          public class VendorServiceViewModel
          {
                public int Id {get;set;}
public int? VendorId {get;set;}
public int? ServiceId {get;set;}
public int? Modifiedby {get;set;}
public System.DateTime? Modifieddate {get;set;}

                 public List<SelectListItem> Dropdownvendor { get; set; }
 public List<SelectListItem> DropdownService { get; set; }

                
          }
        public class VendorServiceListViewModel
        {
            public List<VendorServiceResponseModel> List { get; set; }
              public List<SelectListItem> Dropdownvendor { get; set; }
 public List<SelectListItem> DropdownService { get; set; }

             
           
        }
        public class VendorServiceFilter
        {
            
            public bool FilterSwitch { get; set; }
        }
}
   


