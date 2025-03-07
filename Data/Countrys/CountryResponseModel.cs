// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Collections.Generic;
using Domain.Entities;

namespace Data.Countrys
{
          public class CountryResponseModel
          {
                public int Id {get;set;}
public string Shortname {get;set;}
public string Name {get;set;}
public string Phonecode {get;set;}
public int? CreatedBy {get;set;}
public int? ModifiedBy {get;set;}
public System.DateTime? CreatedDate {get;set;}
public System.DateTime? ModifiedDate {get;set;}
public bool? IsActive {get;set;}
public bool IsDeleted {get;set;}

          }
        
}
   


