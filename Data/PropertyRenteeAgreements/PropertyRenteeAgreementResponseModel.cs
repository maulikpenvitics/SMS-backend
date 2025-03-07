// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Collections.Generic;
using Domain.Entities;

namespace Data.PropertyRenteeAgreements
{
          public class PropertyRenteeAgreementResponseModel
          {
                public int Id {get;set;}
public int? PropertyId {get;set;}
public int? BlockId {get;set;}
public int? Unitid {get;set;}
public string Agreementurl {get;set;}
public int? PropertyRenteeId {get;set;}
public string PropertyRenteeName {get;set;}
public System.DateTime? Agreementstartdate {get;set;}
public System.DateTime? Agreementenddate {get;set;}
public int? Modifiedby {get;set;}
public System.DateTime? Modifieddate {get;set;}

          }
        
}
   


