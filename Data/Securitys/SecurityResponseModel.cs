// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Collections.Generic;
using Domain.Entities;

namespace Data.Securitys
{
          public class SecurityResponseModel
          {
                public int Id {get;set;}
public int? ResidentId {get;set;}
public string ResidentName {get;set;}
public int? UserId {get;set;}
public string UserName {get;set;}
public int? VendorId {get;set;}
public string VendorName {get;set;}
public string Incidence {get;set;}
public string Securitydesc {get;set;}
public int? Modifiedby {get;set;}
public System.DateTime? Modifieddate {get;set;}

          }
        
}
   


