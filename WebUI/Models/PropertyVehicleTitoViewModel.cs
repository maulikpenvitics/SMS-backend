// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Collections.Generic;
using Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
 using Data.PropertyVehicles;
 using Data.PropertyVehicleTitos;


namespace WebUI.Models
{
          public class PropertyVehicleTitoViewModel
          {
                public int Id {get;set;}
public int? PropertyVehicleId {get;set;}
public System.DateTime? Checkintime {get;set;}
public System.DateTime? Checkouttime {get;set;}
public int? Modifiedby {get;set;}
public System.DateTime? Modifieddate {get;set;}

                 public List<SelectListItem> DropdownPropertyVehicle { get; set; }

                
          }
        public class PropertyVehicleTitoListViewModel
        {
            public List<PropertyVehicleTitoResponseModel> List { get; set; }
              public List<SelectListItem> DropdownPropertyVehicle { get; set; }

             
           
        }
        public class PropertyVehicleTitoFilter
        {
            
            public bool FilterSwitch { get; set; }
        }
}
   


