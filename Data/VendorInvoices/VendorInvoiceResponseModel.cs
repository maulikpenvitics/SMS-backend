// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Collections.Generic;
using Domain.Entities;

namespace Data.VendorInvoices
{
          public class VendorInvoiceResponseModel
          {
                public int Id {get;set;}
public int? VendorId {get;set;}
public string vendorName {get;set;}
public System.DateTime? Invoicedate {get;set;}
public System.DateTime? Todate {get;set;}
public decimal? Amount {get;set;}
public System.DateTime? Duedate {get;set;}
public decimal? Tax {get;set;}
public decimal? NetAmount {get;set;}
public int? Modifiedby {get;set;}
public System.DateTime? Modifieddate {get;set;}

          }
        
}
   


