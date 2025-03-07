// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Collections.Generic;
using Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
 using Data.Visitors;


namespace WebUI.Models
{
          public class VisitorViewModel
          {
                public int Id {get;set;}
public string Firstname {get;set;}
public string Lastname {get;set;}
public int? Idno {get;set;}
public string Idtype {get;set;}
public int? Gatepass {get;set;}
public string Phoneno {get;set;}
public int? Modifiedby {get;set;}
public System.DateTime? Modifieddate {get;set;}

                
                
          }
        public class VisitorListViewModel
        {
            public List<VisitorResponseModel> List { get; set; }
             
             
           
        }
        public class VisitorFilter
        {
            public int VisitorIdno {get;set;}
public int VisitorGatepass {get;set;}
public string VisitorPhoneno {get;set;}

            public bool FilterSwitch { get; set; }
        }
}
   


