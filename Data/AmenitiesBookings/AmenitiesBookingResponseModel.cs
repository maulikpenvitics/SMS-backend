// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Collections.Generic;
using Domain.Entities;

namespace Data.AmenitiesBookings
{
          public class AmenitiesBookingResponseModel
          {
                public int Id {get;set;}
public int? PropertyId {get;set;}
public string PropertyName {get;set;}
public int? PropertyAmenitiesId {get;set;}
public string propertyamenitiesName {get;set;}
public int? UserId {get;set;}
public string UserName {get;set;}
public int? Amenitiesstatus {get;set;}
public System.DateTime? Availabilitytimeslots {get;set;}
public string Bokingpurpose {get;set;}
public System.String Checkintime {get;set;}
public System.String Checkouttime {get;set;}
public int? Modifiedby {get;set;}
public System.DateTime? Modifieddate {get;set;}

          }
        
}
   


