// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Collections.Generic;
using Domain.Entities;

namespace Data.UserRoles
{
          public class UserRoleResponseModel
          {
                public int Id {get;set;}
public int? UserId {get;set;}
public string userName {get;set;}
public int? RoleId {get;set;}
public string roleName {get;set;}
public int? Modifiedby {get;set;}
public System.DateTime? Modifieddate {get;set;}

          }
        
}
   


