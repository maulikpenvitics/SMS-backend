// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Collections.Generic;
using Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
 using Data.VendorInvoiceDetails;


namespace WebUI.Models
{
          public class VendorInvoiceDetailViewModel
          {
                public int Id {get;set;}
public int? VendorInvoiceId {get;set;}
public string Lineitem {get;set;}
public decimal? Amount {get;set;}
public string Description {get;set;}
public int? Modifiedby {get;set;}
public System.DateTime? Modifieddate {get;set;}

                
                
          }
        public class VendorInvoiceDetailListViewModel
        {
            public List<VendorInvoiceDetailResponseModel> List { get; set; }
             
             
           
        }
        public class VendorInvoiceDetailFilter
        {
            
            public bool FilterSwitch { get; set; }
        }
}
   


