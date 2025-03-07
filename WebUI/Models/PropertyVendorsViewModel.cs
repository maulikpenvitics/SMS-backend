// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Collections.Generic;
using Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
 using Data.Propertys;
 using Data.PropertyVendorss;


namespace WebUI.Models
{
          public class PropertyVendorsViewModel
          {
                public int Id {get;set;}
public int? PropertyId {get;set;}
public int? VendorId {get;set;}
public int? Modifiedby {get;set;}
public System.DateTime? Modifieddate {get;set;}

                 public List<SelectListItem> DropdownProperty { get; set; }

                
          }
        public class PropertyVendorsListViewModel
        {
            public List<PropertyVendorsResponseModel> List { get; set; }
              public List<SelectListItem> DropdownProperty { get; set; }

             
           
        }
        public class PropertyVendorsFilter
        {
            
            public bool FilterSwitch { get; set; }
        }
}
   


