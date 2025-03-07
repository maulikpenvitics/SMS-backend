// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Collections.Generic;
using Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
 using Data.Citys;
 using Data.States;
 using Data.Countrys;
 using Data.Vendors;


namespace WebUI.Models
{
          public class VendorViewModel
          {
                public int Id {get;set;}
public string Firstname {get;set;}
public string Lastname {get;set;}
public string Companyname {get;set;}
public string Address1 {get;set;}
public string Address2 {get;set;}
public int? Cityid {get;set;}
public int? Stateid {get;set;}
public int? Countryid {get;set;}
public int? ModifiedBy {get;set;}
public System.DateTime? ModifiedDate {get;set;}

                 public List<SelectListItem> DropdownCity { get; set; }
 public List<SelectListItem> DropdownState { get; set; }
 public List<SelectListItem> DropdownCountry { get; set; }

                
          }
        public class VendorListViewModel
        {
            public List<VendorResponseModel> List { get; set; }
              public List<SelectListItem> DropdownCity { get; set; }
 public List<SelectListItem> DropdownState { get; set; }
 public List<SelectListItem> DropdownCountry { get; set; }

             
           
        }
        public class VendorFilter
        {
            public string VendorFirstname {get;set;}
public string VendorLastname {get;set;}
public string VendorCompanyname {get;set;}

            public bool FilterSwitch { get; set; }
        }
}
   


