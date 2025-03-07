// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Collections.Generic;
using Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
 using Data.Reportss;


namespace WebUI.Models
{
          public class ReportsViewModel
          {
                public int Id {get;set;}
public string Name {get;set;}
public int? Modifiedby {get;set;}
public System.DateTime? Modifieddate {get;set;}

                
                
          }
        public class ReportsListViewModel
        {
            public List<ReportsResponseModel> List { get; set; }
             
             
           
        }
        public class ReportsFilter
        {
            
            public bool FilterSwitch { get; set; }
        }
}
   


