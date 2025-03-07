// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Collections.Generic;
using Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
 using Data.States;
 using Data.Citys;


namespace WebUI.Models
{
          public class CityViewModel
          {
                public int Id {get;set;}
public string Name {get;set;}
public int StateId {get;set;}
public int? CreatedBy {get;set;}
public int? ModifiedBy {get;set;}
public System.DateTime? CreatedDate {get;set;}
public System.DateTime? ModifiedDate {get;set;}
public bool? IsActive {get;set;}
public bool IsDeleted {get;set;}

                 public List<SelectListItem> DropdownState { get; set; }

                
          }
        public class CityListViewModel
        {
            public List<CityResponseModel> List { get; set; }
              public List<SelectListItem> DropdownState { get; set; }

             
           
        }
        public class CityFilter
        {
            
            public bool FilterSwitch { get; set; }
        }
}
   


