// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Collections.Generic;
using Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
 using Data.Propertys;
 using Data.Roles;
 using Data.Users;


namespace WebUI.Models
{
          public class UserViewModel
          {
                public int Id {get;set;}
public string Username {get;set;}

[Required(ErrorMessage = "Password is required.")]
[DataType(DataType.Password)]
public string Password { get; set; }

[Required(ErrorMessage = "Confirm Password is required.")]
[DataType(DataType.Password)]
[System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "Passwords do not match.")]
public string ConfirmPassword { get; set; }

[Required(ErrorMessage = "First Name is required.")]
public string Firstname { get; set; }

[Required(ErrorMessage = "Last Name is required.")]
public string Lastname { get; set; }

[Required(ErrorMessage = "Email is required.")]
[EmailAddress(ErrorMessage = "Invalid email format.")]
public string Email { get; set; }

[Required(ErrorMessage = "Phone number is required.")]
[RegularExpression(@"^\d{10}$", ErrorMessage = "Phone number must be exactly 10 digits.")]
public string Phone { get; set; }
public int? PropertyId {get;set;}
public int? RoleId {get;set;}
public int? Modifiedby {get;set;}
public System.DateTime? Modifieddate {get;set;}

                 public List<SelectListItem> Dropdownproperty { get; set; }
 public List<SelectListItem> Dropdownrole { get; set; }

                
          }
        public class UserListViewModel
        {
            public List<UserResponseModel> List { get; set; }
              public List<SelectListItem> Dropdownproperty { get; set; }
 public List<SelectListItem> Dropdownrole { get; set; }

             
           
        }
        public class UserFilter
        {
            public string UserPassword {get;set;}
            public string UserPhone {get;set;}

            public bool FilterSwitch { get; set; }
        }
}
   


