// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Collections.Generic;
using Domain.Entities;

namespace Data.VendorServices
{
          public class VendorServiceResponseModel
          {
                public int Id {get;set;}
public int? VendorId {get;set;}
public string vendorName {get;set;}
public int? ServiceId {get;set;}
public string ServiceName {get;set;}
public int? Modifiedby {get;set;}
public System.DateTime? Modifieddate {get;set;}

          }
        
}
   


