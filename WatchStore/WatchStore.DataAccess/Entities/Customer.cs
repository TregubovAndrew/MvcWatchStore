﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WatchStore.DataAccess.Entities
{
    public class Customer : User
    {
       
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int PostalCode { get; set; }

        public string Country { get; set; }

        public string City { get; set; }

        public string Address { get; set; }

        public int Phone { get; set; }

    }
}
