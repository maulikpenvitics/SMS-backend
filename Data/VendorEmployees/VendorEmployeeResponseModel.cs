// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Collections.Generic;
using Domain.Entities;

namespace Data.VendorEmployees
{
          public class VendorEmployeeResponseModel
          {
                public int VendorEmployeeId {get;set;}
public int? VendorId {get;set;}
public string vendorName {get;set;}
public int? Id {get;set;}
public string Firstname {get;set;}
public string Lastname {get;set;}
public string Phoneno {get;set;}
public string Address1 {get;set;}
public string Address2 {get;set;}
public int? Cityid {get;set;}
public string CityName {get;set;}
public int? Stateid {get;set;}
public string StateName {get;set;}
public int? Countryid {get;set;}
public string CountryName {get;set;}
public int? Modifiedby {get;set;}
public System.DateTime? Modifieddate {get;set;}

          }
        
}
   


