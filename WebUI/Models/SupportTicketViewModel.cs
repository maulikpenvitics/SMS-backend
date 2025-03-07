// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Collections.Generic;
using Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
 using Data.Services;
 using Data.Vendors;
 using Data.SupportTickets;
using Data.Users;


namespace WebUI.Models
{
          public class SupportTicketViewModel
          {
                public int Id {get;set;}
        public int? UserId {get;set;}
public string Ticket {get;set;}
public string Description {get;set;}
public string Severity {get;set;}
public string Duedate {get;set;}
public int? ServiceId {get;set;}
public string Status {get;set;}
public string Comment {get;set;}
public int? VendorEmployeeId {get;set;}
public int? VendorId {get;set;}
public int? Modifiedby {get;set;}
public System.DateTime? Modifieddate {get;set;}

        public List<SelectListItem> Dropdownuser { get; set; }
        public List<SelectListItem> Dropdownservice { get; set; }
 public List<SelectListItem> Dropdownvendor { get; set; }

                
          }
        public class SupportTicketListViewModel
        {
        public List<SupportTicketResponseModel> List { get; set; }
        public List<SelectListItem> Dropdownuser { get; set; }
              public List<SelectListItem> Dropdownservice { get; set; }
 public List<SelectListItem> Dropdownvendor { get; set; }

             
           
        }
        public class SupportTicketFilter
        {
            
            public bool FilterSwitch { get; set; }
        }
}
   


