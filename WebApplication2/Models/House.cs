using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace WebApplication2.Models
{
    public class House
    {
        public int ID { get; set; }
        public string Street1 { get; set; }
        public string Street2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zipcode { get; set; }
        public string Neighborhood { get; set; }
        public string SalesPrice { get; set; }
        public string DateListed { get; set; }
        public string Bedrooms { get; set; }
        public string Bathrooms { get; set; }
        public string GarageSize { get; set; }
        public string SquareFeet { get; set; }
        public string LotSize { get; set; }
        public string Description { get; set; }

    }

    public class HouseDBContext : DbContext
    {
        public DbSet<House> Houses { get; set; }
    }
}