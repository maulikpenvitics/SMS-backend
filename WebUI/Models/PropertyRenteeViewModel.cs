// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Collections.Generic;
using Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
 using Data.PropertyRentees;


namespace WebUI.Models
{
          public class PropertyRenteeViewModel
          {
                public int Id {get;set;}
public string Firstname {get;set;}
public string Lastname {get;set;}
public string Email {get;set;}
public string Phoneno {get;set;}
public int? BlockId {get;set;}
public int? Unitno {get;set;}
public string Profession {get;set;}
public int? Modifiedby {get;set;}
public System.DateTime? Modifieddate {get;set;}

                
                
          }
        public class PropertyRenteeListViewModel
        {
            public List<PropertyRenteeResponseModel> List { get; set; }
             
             
           
        }
        public class PropertyRenteeFilter
        {
            public string PropertyRenteeFirstname {get;set;}
public string PropertyRenteeLastname {get;set;}

            public bool FilterSwitch { get; set; }
        }
}
   


