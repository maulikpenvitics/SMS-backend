// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Collections.Generic;
using Domain.Entities;

namespace Data.Accountings
{
          public class AccountingResponseModel
          {
                public int Id {get;set;}
public string Accountname {get;set;}
public int UserId { get; set; }
public string Username { get; set; }
public int? PropertyId {get;set;}
public string Propertyname {get;set;}
public int? VendorId {get;set;}
public string Vendorname {get;set;}
public int? Accountid {get;set;}
public string Accountno {get;set;}
public int? Balance {get;set;}
public string Entitytype {get;set;}
public int? Modifiedby {get;set;}
public System.DateTime? Modifieddate {get;set;}

          }
        
}
   


