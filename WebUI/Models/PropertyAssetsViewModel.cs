// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Collections.Generic;
using Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
 using Data.Propertys;
 using Data.PropertyAssetss;


namespace WebUI.Models
{
          public class PropertyAssetsViewModel
          {
                public int Id {get;set;}
public int? PropertyId {get;set;}
public string Assetname {get;set;}
public int? Assetnumber {get;set;}
public int? Modifiedby {get;set;}
public System.DateTime? Modifieddate {get;set;}

                 public List<SelectListItem> DropdownProperty { get; set; }

                
          }
        public class PropertyAssetsListViewModel
        {
            public List<PropertyAssetsResponseModel> List { get; set; }
              public List<SelectListItem> DropdownProperty { get; set; }

             
           
        }
        public class PropertyAssetsFilter
        {
            public string PropertyAssetsAssetname {get;set;}

            public bool FilterSwitch { get; set; }
        }
}
   


