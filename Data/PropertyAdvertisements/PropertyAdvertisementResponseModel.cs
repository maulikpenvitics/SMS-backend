// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Collections.Generic;
using Domain.Entities;

namespace Data.PropertyAdvertisements
{
          public class PropertyAdvertisementResponseModel
          {
                public int Id {get;set;}
public int? PropertyId {get;set;}
public string PropertyName {get;set;}
public string Location {get;set;}
public System.DateTime? Fromdate {get;set;}
public System.DateTime? Todate {get;set;}
public decimal? Amount {get;set;}
public string Companyname {get;set;}
public string Advertisorfirstname {get;set;}
public string Advertisorlastname {get;set;}
public int? Modifiedby {get;set;}
public System.DateTime? Modifieddate {get;set;}

          }
        
}
   


