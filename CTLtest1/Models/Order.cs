using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CTLtest1.Models
{
    public class Order
    {
        public long OrderId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Addr1 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public long Postal { get; set; }
        public string SKU { get; set; }
        public long Quantity { get; set; }

    }
}