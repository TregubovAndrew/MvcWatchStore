using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WatchStore.DataAccess.Entities
{
    public class Watch
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public string Colour { get; set; }
        public string WaterResistance { get; set; }
        public int Warranty { get; set; }
    }
}
