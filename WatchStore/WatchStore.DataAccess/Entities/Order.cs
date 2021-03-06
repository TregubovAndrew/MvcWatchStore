﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WatchStore.DataAccess.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public decimal Sum { get; set;}
        public DateTime Date { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int PostalCode { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public int Phone { get; set; }

        //public virtual ICollection<Watch> Watches { get; set; }
        public virtual ICollection<OrderWatch> OrderWatches { get; set; }
    }
}
