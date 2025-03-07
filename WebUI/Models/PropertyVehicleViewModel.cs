// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Collections.Generic;
using Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
 using Data.Propertys;
 using Data.PropertyVehicles;


namespace WebUI.Models
{
          public class PropertyVehicleViewModel
          {
                public int Id {get;set;}
public int? PropertyId {get;set;}
public int? Vehiclenumber {get;set;}
public string Model {get;set;}
public int? PropertyOwnersId {get;set;}
public int? Modifiedby {get;set;}
public System.DateTime? Modifieddate {get;set;}

                 public List<SelectListItem> DropdownProperty { get; set; }

                
          }
        public class PropertyVehicleListViewModel
        {
            public List<PropertyVehicleResponseModel> List { get; set; }
              public List<SelectListItem> DropdownProperty { get; set; }

             
           
        }
        public class PropertyVehicleFilter
        {
            
            public bool FilterSwitch { get; set; }
        }
}
   


