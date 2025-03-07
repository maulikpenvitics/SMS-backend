// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Collections.Generic;
using Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
 using Data.Citys;
 using Data.States;
 using Data.Countrys;
 using Data.Propertys;


namespace WebUI.Models
{
          public class PropertyViewModel
          {
                public int Id {get;set;}
public string Propertyname {get;set;}
public string Address1 {get;set;}
public string Address2 {get;set;}
public int? Cityid {get;set;}
public int? Stateid {get;set;}
public int? Countryid {get;set;}
public int? Zipcode {get;set;}
public string Phoneno {get;set;}
public string Email {get;set;}
public int? Modifiedby {get;set;}
public System.DateTime? Modifieddate {get;set;}

                 public List<SelectListItem> DropdownCity { get; set; }
 public List<SelectListItem> DropdownState { get; set; }
 public List<SelectListItem> DropdownCountry { get; set; }

                
          }
        public class PropertyListViewModel
        {
            public List<PropertyResponseModel> List { get; set; }
              public List<SelectListItem> DropdownCity { get; set; }
 public List<SelectListItem> DropdownState { get; set; }
 public List<SelectListItem> DropdownCountry { get; set; }

             
           
        }
        public class PropertyFilter
        {
            public string PropertyPropertyname {get;set;}

            public bool FilterSwitch { get; set; }
        }
}
   


