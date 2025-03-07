// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Collections.Generic;
using Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
 using Data.PropertyOwnerss;


namespace WebUI.Models
{
          public class PropertyOwnersViewModel
          {
                public int Id {get;set;}
public string Firstname {get;set;}
public string Lastname {get;set;}
public string Email {get;set;}
public string Phoneno {get;set;}
public int? BlockId {get;set;}
public int? Modifiedby {get;set;}
public System.DateTime? Modifieddate {get;set;}

                
                
          }
        public class PropertyOwnersListViewModel
        {
            public List<PropertyOwnersResponseModel> List { get; set; }
             
             
           
        }
        public class PropertyOwnersFilter
        {
            public string PropertyOwnersFirstname {get;set;}
public string PropertyOwnersLastname {get;set;}

            public bool FilterSwitch { get; set; }
        }
}
   


