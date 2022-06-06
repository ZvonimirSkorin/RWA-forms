using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Zadatak01.Model
{
    public class Apartment
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string NameEng { get; set; }
        public string Address { get; set; }
        public decimal Price { get; set; }
        public int MaxAdults { get; set; }
        public int MaxChildren { get; set; }
        public int TotalRooms { get; set; }
        public int BeachDistance { get; set; }
        public int Owner { get; set; }
        public int Status { get; set; }
        public string City { get; set; }

    }
}