using System;
using Domain.Entities;

namespace Data.Units
{
    public class UnitResponseModel
    {
        public int Id { get; set; }
        public string Unitname { get; set; }
        public int? BlockId { get; set; }
    }
}
