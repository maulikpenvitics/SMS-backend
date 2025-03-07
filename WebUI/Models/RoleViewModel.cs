// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Collections.Generic;
using Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
 using Data.Roles;


namespace WebUI.Models
{
          public class RoleViewModel
          {
                public int Id {get;set;}
public string Name {get;set;}
public int? ModifiedBy {get;set;}
public System.DateTime? ModifiedDate {get;set;}

                
                
          }
        public class RoleListViewModel
        {
            public List<RoleResponseModel> List { get; set; }
             
             
           
        }
        public class RoleFilter
        {
            
            public bool FilterSwitch { get; set; }
        }
}
   


