// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Collections.Generic;
using Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
 using Data.Visitors;
 using Data.Directorys;


namespace WebUI.Models
{
          public class DirectoryViewModel
          {
                public int? Id {get;set;}
public string Discription {get;set;}
public int? Bussinessid {get;set;}
public int? VisitorId {get;set;}
public int? Modifiedby {get;set;}
public System.DateTime? Modifieddate {get;set;}

                 public List<SelectListItem> DropdownVisitor { get; set; }

                
          }
        public class DirectoryListViewModel
        {
            public List<DirectoryResponseModel> List { get; set; }
              public List<SelectListItem> DropdownVisitor { get; set; }

             
           
        }
        public class DirectoryFilter
        {
            
            public bool FilterSwitch { get; set; }
        }
}
   


