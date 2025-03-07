// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Collections.Generic;
using Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
 using Data.Propertys;
 using Data.PropertyAmenitiess;
 using Data.Users;
 using Data.AmenitiesBookings;


namespace WebUI.Models
{
          public class AmenitiesBookingViewModel
          {
                public int Id {get;set;}
public int? PropertyId {get;set;}
public int? PropertyAmenitiesId {get;set;}
public int? UserId {get;set;}
public int? Amenitiesstatus {get;set;}
public System.DateTime? Availabilitytimeslots {get;set;}
public string Bokingpurpose {get;set;}
public System.String Checkintime {get;set;}
public System.String Checkouttime {get;set;}
public int? Modifiedby {get;set;}
public System.DateTime? Modifieddate {get;set;}

                 public List<SelectListItem> DropdownProperty { get; set; }
 public List<SelectListItem> Dropdownpropertyamenities { get; set; }
 public List<SelectListItem> DropdownUser { get; set; }

                
          }
        public class AmenitiesBookingListViewModel
        {
            public List<AmenitiesBookingResponseModel> List { get; set; }
              public List<SelectListItem> DropdownProperty { get; set; }
 public List<SelectListItem> Dropdownpropertyamenities { get; set; }
 public List<SelectListItem> DropdownUser { get; set; }

             
           
        }
        public class AmenitiesBookingFilter
        {
            
            public bool FilterSwitch { get; set; }
        }
}
   


