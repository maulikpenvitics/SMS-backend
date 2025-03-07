// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Collections.Generic;
using Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
 using Data.VisitorVisits;


namespace WebUI.Models
{
          public class VisitorVisitViewModel
          {
                public int Id {get;set;}
public int? VisitorId {get;set;}
public System.DateTime? Checkin {get;set;}
public System.DateTime? Checkout {get;set;}
public int? BlockId {get;set;}
public string Unit {get;set;}
public int? Gatepass {get;set;}
public int? UserId {get;set;}
public string Purpose {get;set;}
public int? Modifiedby {get;set;}
public System.DateTime? Modifieddate {get;set;}

                
                
          }
        public class VisitorVisitListViewModel
        {
            public List<VisitorVisitResponseModel> List { get; set; }
             
             
           
        }
        public class VisitorVisitFilter
        {
            
            public bool FilterSwitch { get; set; }
        }
}
   


