// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Collections.Generic;
using Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
 using Data.Categorys;


namespace WebUI.Models
{
          public class CategoryViewModel
          {
                public int Id {get;set;}
public string Name {get;set;}
public int? CreatedBy {get;set;}
public int? ModifiedBy {get;set;}
public System.DateTime? CreatedDate {get;set;}
public System.DateTime? ModifiedDate {get;set;}
public bool IsActive {get;set;}
public bool IsDeleted {get;set;}

                
                
          }
        public class CategoryListViewModel
        {
            public List<CategoryResponseModel> List { get; set; }
             
             
           
        }
        public class CategoryFilter
        {
            
            public bool FilterSwitch { get; set; }
        }
}
   


