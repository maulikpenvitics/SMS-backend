// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Collections.Generic;
using Domain.Entities;

namespace Data.SupportTickets
{
          public class SupportTicketResponseModel
          {
                public int Id {get;set;}
        public int UserId { get; set; }
        public string Username { get; set; }
public string Ticket {get;set;}
public string Description {get;set;}
public string Severity {get;set;}
public string Duedate {get;set;}
public int? ServiceId {get;set;}
public string Servicename {get;set;}
public string Status {get;set;}
public string Comment {get;set;}
public int? VendorEmployeeId {get;set;}
public int? VendorId {get;set;}
public string Vendorname {get;set;}
public int? Modifiedby {get;set;}
public System.DateTime? Modifieddate {get;set;}

          }
        
}
   


