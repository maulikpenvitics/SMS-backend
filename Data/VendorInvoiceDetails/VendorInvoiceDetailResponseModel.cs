// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Collections.Generic;
using Domain.Entities;

namespace Data.VendorInvoiceDetails
{
          public class VendorInvoiceDetailResponseModel
          {
                public int Id {get;set;}
public int? VendorInvoiceId {get;set;}
public string Lineitem {get;set;}
public decimal? Amount {get;set;}
public string Description {get;set;}
public int? Modifiedby {get;set;}
public System.DateTime? Modifieddate {get;set;}

          }
        
}
   


