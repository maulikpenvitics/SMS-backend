// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Collections.Generic;
using Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
 using Data.PropertyRentees;
 using Data.PropertyRenteeAgreements;


namespace WebUI.Models
{
          public class PropertyRenteeAgreementViewModel
          {
                public int Id {get;set;}
public int? PropertyId {get;set;}
public int? BlockId {get;set;}
public int? Unitid {get;set;}
public string Agreementurl {get;set;}
public int? PropertyRenteeId {get;set;}
public System.DateTime? Agreementstartdate {get;set;}
public System.DateTime? Agreementenddate {get;set;}
public int? Modifiedby {get;set;}
public System.DateTime? Modifieddate {get;set;}

                 public List<SelectListItem> DropdownPropertyRentee { get; set; }

                
          }
        public class PropertyRenteeAgreementListViewModel
        {
            public List<PropertyRenteeAgreementResponseModel> List { get; set; }
              public List<SelectListItem> DropdownPropertyRentee { get; set; }

             
           
        }
        public class PropertyRenteeAgreementFilter
        {
            
            public bool FilterSwitch { get; set; }
        }
}
   


