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

        public string BrandOld { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public string CaseMaterial { get; set; }

        public float CaseDiameter { get; set; }

        public string Lens { get; set; }

        public string Strap { get; set; }

        public string Mechanism { get; set; }

        public string WaterResistance { get; set; }

        public int Warranty { get; set; }

        public string Colour { get; set; }

        public string Category { get; set; }

        public virtual ICollection<Image> Images { get; set; }

        public virtual ICollection<OrderWatch> OrderWatches { get; set; }

        public int? BrandId { get; set; }

        public virtual Brand Brand { get; set; }

    }
}
