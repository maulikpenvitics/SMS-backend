// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Collections.Generic;
using Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
 using Data.VendorEmployees;
 using Data.VendorEmpRatings;


namespace WebUI.Models
{
          public class VendorEmpRatingViewModel
          {
                public int Id {get;set;}
public int? Overallrating {get;set;}
public int? VendorEmployeeId {get;set;}
public int? Modifiedby {get;set;}
public System.DateTime? Modifieddate {get;set;}

                 public List<SelectListItem> DropdownVendorEmployee { get; set; }

                
          }
        public class VendorEmpRatingListViewModel
        {
            public List<VendorEmpRatingResponseModel> List { get; set; }
              public List<SelectListItem> DropdownVendorEmployee { get; set; }

             
           
        }
        public class VendorEmpRatingFilter
        {
            
            public bool FilterSwitch { get; set; }
        }
}
   


