// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Collections.Generic;
using Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
 using Data.Users;
 using Data.Roles;
 using Data.UserRoles;


namespace WebUI.Models
{
          public class UserRoleViewModel
          {
                public int Id {get;set;}
public int? UserId {get;set;}
public int? RoleId {get;set;}
public int? Modifiedby {get;set;}
public System.DateTime? Modifieddate {get;set;}

                 public List<SelectListItem> Dropdownuser { get; set; }
 public List<SelectListItem> Dropdownrole { get; set; }

                
          }
        public class UserRoleListViewModel
        {
            public List<UserRoleResponseModel> List { get; set; }
              public List<SelectListItem> Dropdownuser { get; set; }
 public List<SelectListItem> Dropdownrole { get; set; }

             
           
        }
        public class UserRoleFilter
        {
            
            public bool FilterSwitch { get; set; }
        }
}
   


