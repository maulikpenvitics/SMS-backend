// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Collections.Generic;
using Domain.Entities;

namespace Data.VendorContracts
{
          public class VendorContractResponseModel
          {
                public int Id {get;set;}
public int? VendorId {get;set;}
public string vendorName {get;set;}
public string Contracturl {get;set;}
public System.DateTime? Fromdate {get;set;}
public System.DateTime? Todate {get;set;}
public decimal? Amount {get;set;}
public string Paymentcycle {get;set;}
public int? Modifiedby {get;set;}
public System.DateTime? Modifieddate {get;set;}

          }
        
}
   


