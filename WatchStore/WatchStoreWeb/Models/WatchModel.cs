using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using WatchStore.DataAccess.Entities;
using Image = WatchStore.DataAccess.Entities.Image;

namespace WatchStoreWeb.Models
{
    public class WatchModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
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
        public HttpPostedFileBase File { get; set; }
        public ICollection<Image> Images { get; set; }
        //public ICollection<Order> Orders { get; set; }
        public ICollection<OrderWatch> OrderWatches { get; set; }

        public WatchModel()
        {
            OrderWatches = new List<OrderWatch>();
        }

        public static WatchModel ConvertToWatchModel(Watch watch)
        {
            if (watch == null)
                return new WatchModel();

            return new WatchModel()
            {
                Id = watch.Id,
                Name = watch.Name,
                Brand = watch.Brand,
                Price = watch.Price,
                Description = watch.Description,
                CaseMaterial = watch.CaseMaterial,
                CaseDiameter = watch.CaseDiameter,
                Lens = watch.Lens,
                Strap = watch.Strap,
                Mechanism = watch.Mechanism,
                WaterResistance = watch.WaterResistance,
                Warranty = watch.Warranty,
                Colour = watch.Colour,
                Category = watch.Category,
                Images = watch.Images,
                OrderWatches = watch.OrderWatches
                //Orders = watch.Orders
                
            };
        }

        public static Watch ConvertToWatch(WatchModel watch)
        {
            if (watch == null)
                return new Watch();

            return new Watch()
            {
                Id = watch.Id,
                Name = watch.Name,
                Brand = watch.Brand,
                Price = watch.Price,
                Description = watch.Description,
                CaseMaterial = watch.CaseMaterial,
                CaseDiameter = watch.CaseDiameter,
                Lens = watch.Lens,
                Strap = watch.Strap,
                Mechanism = watch.Mechanism,
                WaterResistance = watch.WaterResistance,
                Warranty = watch.Warranty,
                Colour = watch.Colour,
                Category = watch.Category,
                Images = watch.Images,
                OrderWatches = watch.OrderWatches
                //Orders = watch.Orders
            };
        }
        
    }
}