// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Domain.Entities;
using Data.Blocks;
using Data.Units;

namespace WebUI.Models
{
    public class UnitViewModel
    {
        public int Id { get; set; }
        public string Unitname { get; set; }
        public int? BlockId { get; set; }

        public List<SelectListItem> DropdownBlock { get; set; }
    }

    public class UnitListViewModel
    {
        public List<UnitResponseModel> List { get; set; }
        public List<SelectListItem> DropdownBlock { get; set; }
    }

    public class UnitFilter
    {
        public string Unitname { get; set; }
        public bool FilterSwitch { get; set; }
    }
}
