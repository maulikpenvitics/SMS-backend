// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Collections.Generic;
using Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
 using Data.Vendors;
 using Data.Citys;
 using Data.States;
 using Data.Countrys;
 using Data.VendorEmployees;


namespace WebUI.Models
{
          public class VendorEmployeeViewModel
          {
                public int VendorEmployeeId {get;set;}
public int? VendorId {get;set;}
public int? Id {get;set;}
public string Firstname {get;set;}
public string Lastname {get;set;}
public string Phoneno {get;set;}
public string Address1 {get;set;}
public string Address2 {get;set;}
public int? Cityid {get;set;}
public int? Stateid {get;set;}
public int? Countryid {get;set;}
public int? Modifiedby {get;set;}
public System.DateTime? Modifieddate {get;set;}

                 public List<SelectListItem> Dropdownvendor { get; set; }
 public List<SelectListItem> DropdownCity { get; set; }
 public List<SelectListItem> DropdownState { get; set; }
 public List<SelectListItem> DropdownCountry { get; set; }

                
          }
        public class VendorEmployeeListViewModel
        {
            public List<VendorEmployeeResponseModel> List { get; set; }
              public List<SelectListItem> Dropdownvendor { get; set; }
 public List<SelectListItem> DropdownCity { get; set; }
 public List<SelectListItem> DropdownState { get; set; }
 public List<SelectListItem> DropdownCountry { get; set; }

             
           
        }
        public class VendorEmployeeFilter
        {
            
            public bool FilterSwitch { get; set; }
        }
}
   


