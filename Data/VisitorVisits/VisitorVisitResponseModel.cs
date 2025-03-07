// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Collections.Generic;
using Domain.Entities;

namespace Data.VisitorVisits
{
          public class VisitorVisitResponseModel
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
        
}
   


