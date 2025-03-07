// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Collections.Generic;
using Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
 using Data.Billings;


namespace WebUI.Models
{
          public class BillingViewModel
          {
                public int Id {get;set;}
public int? Debitaccountid {get;set;}
public int? Modifiedby {get;set;}
public System.DateTime? Modifieddate {get;set;}

                
                
          }
        public class BillingListViewModel
        {
            public List<BillingResponseModel> List { get; set; }
             
             
           
        }
        public class BillingFilter
        {
            
            public bool FilterSwitch { get; set; }
        }
}
   


