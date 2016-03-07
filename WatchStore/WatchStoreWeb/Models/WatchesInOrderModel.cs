using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WatchStore.DataAccess.Entities;

namespace WatchStoreWeb.Models
{
    public class WatchesInOrderModel
    {
        public Watch Watch { get; set; }

        public int Quantity { get; set; }

        public int OrderId { get; set; }
    }
}