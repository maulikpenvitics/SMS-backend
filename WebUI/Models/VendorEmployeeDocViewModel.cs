// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Collections.Generic;
using Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
 using Data.VendorEmployeeDocs;


namespace WebUI.Models
{
          public class VendorEmployeeDocViewModel
          {
                public int Id {get;set;}
public string Docurl {get;set;}
public string Doctype {get;set;}
public int? VendorEmployeeId {get;set;}
public int? Modifiedby {get;set;}
public System.DateTime? Modifieddate {get;set;}

                
                
          }
        public class VendorEmployeeDocListViewModel
        {
            public List<VendorEmployeeDocResponseModel> List { get; set; }
             
             
           
        }
        public class VendorEmployeeDocFilter
        {
            
            public bool FilterSwitch { get; set; }
        }
}
   


