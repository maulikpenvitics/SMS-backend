// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Collections.Generic;
using Domain.Entities;

namespace Data.VendorEmpRatings
{
          public class VendorEmpRatingResponseModel
          {
                public int Id {get;set;}
public int? Overallrating {get;set;}
public int? VendorEmployeeId {get;set;}
public string VendorEmployeeName {get;set;}
public int? Modifiedby {get;set;}
public System.DateTime? Modifieddate {get;set;}

          }
        
}
   


