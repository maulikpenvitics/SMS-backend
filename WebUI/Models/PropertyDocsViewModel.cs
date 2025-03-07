// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Collections.Generic;
using Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
 using Data.Propertys;
 using Data.PropertyDocss;


namespace WebUI.Models
{
          public class PropertyDocsViewModel
          {
                public int Id {get;set;}
public int? PropertyId {get;set;}
public int? UserId {get;set;}
public string Docurl {get;set;}
public int? Modifiedby {get;set;}
public System.DateTime? Modifieddate {get;set;}

                 public List<SelectListItem> DropdownProperty { get; set; }
        public List<SelectListItem> DropdownUser { get; set; }
 

                
          }
        public class PropertyDocsListViewModel
        {
            public List<PropertyDocsResponseModel> List { get; set; }
              public List<SelectListItem> DropdownProperty { get; set; }
        public List<SelectListItem> DropdownUser { get; set; }

             
           
        }
        public class PropertyDocsFilter
        {
            
            public bool FilterSwitch { get; set; }
        }
}
   


