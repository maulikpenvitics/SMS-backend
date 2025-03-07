// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Collections.Generic;
using Domain.Entities;

namespace Data.Residents
{
          public class ResidentResponseModel
          {
                public int Id {get;set;}
public string Username {get;set;}
public string Password {get;set;}
public string Firstname {get;set;}
public string Lastname {get;set;}
public string Email {get;set;}
public string Phoneno {get;set;}
public string Detailedinfo {get;set;}
public int? PropertyId {get;set;}
public string PropertyName {get; set; }
        public int? BlockId { get; set; }

        public string Blockname { get; set; }
        public int UnitId { get; set; }

        public string Unitname { get; set; }
        public int? Modifiedby {get;set;}
public System.DateTime? Modifieddate {get;set;}

          }
        
}
   


