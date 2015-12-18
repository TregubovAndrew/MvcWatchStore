using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WatchStore.DataAccess.Entities
{
    public class OrderWatch
    {
        [Key, Column(Order = 0)]
        public int OrderId { get; set; }

        [Key, Column(Order = 1)]
        public int WatchId { get; set; }

        public virtual Order Order { get; set; }

        public virtual Watch Watch { get; set; }

        public int Quantity { get; set; }
    }
}
