// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Collections.Generic;
using Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
 using Data.Propertys;
 using Data.Vendors;
using Data.Users;
 using Data.Accountings;
using System.EnterpriseServices.Internal;


namespace WebUI.Models
{
          public class AccountingViewModel
          {
                public int Id {get;set;}
public string Accountname {get;set;}
public int UserId { get; set; }
public int? PropertyId {get;set;}
public int? VendorId {get;set;}
public int? Accountid {get;set;}
public string Accountno {get;set;}
public int? Balance {get;set;}
public string Entitytype {get;set;}
public int? Modifiedby {get;set;}
public System.DateTime? Modifieddate {get;set;}

        public List<SelectListItem> DropdownUser { get; set; }
        public List<SelectListItem> DropdownProperty { get; set; }
 public List<SelectListItem> DropdownVendor { get; set; }

                
          }
        public class AccountingListViewModel
        {
            public List<AccountingResponseModel> List { get; set; }

        public List<SelectListItem> DropdownUser { get; set; }
        public List<SelectListItem> DropdownProperty { get; set; }
 public List<SelectListItem> DropdownVendor { get; set; }

             
           
        }
        public class AccountingFilter
        {
            public string AccountingAccountname {get;set;}

            public bool FilterSwitch { get; set; }
        }
}
   


