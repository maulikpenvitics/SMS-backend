// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Collections.Generic;
using Domain.Entities;

namespace Data.Users
{
          public class UserResponseModel
          {
                public int Id {get;set;}
public string Username {get;set;}
public string Password {get;set;}
public string Firstname {get;set;}
public string Lastname {get;set;}
public string Email {get;set;}
public string Phone {get;set;}
public int? PropertyId {get;set;}
public string propertyName {get;set;}
public int? RoleId {get;set;}
public string roleName {get;set;}
public int? Modifiedby {get;set;}
public System.DateTime? Modifieddate {get;set;}

          }
        
}
   


