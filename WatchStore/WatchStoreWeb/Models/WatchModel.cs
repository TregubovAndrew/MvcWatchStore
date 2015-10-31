using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using WatchStore.DataAccess.Entities;

namespace WatchStoreWeb.Models
{
    public class WatchModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public string Colour { get; set; }
        public string WaterResistance { get; set; }
        [Required]
        [Range(1, 10)]
        [Display(Name = "Гарантия")]
        public int Warranty { get; set; }

        public string CurrentCategory { get; set; }

        public static WatchModel ConvertToWatchModel(Watch watch)
        {
            if (watch == null)
                return new WatchModel();

            return new WatchModel()
            {
                Id = watch.Id,
                Name = watch.Name,
                Brand = watch.Brand,
                Colour = watch.Colour,
                WaterResistance = watch.WaterResistance,
                Warranty = watch.Warranty,
                CurrentCategory = watch.Category
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
                Colour = watch.Colour,
                WaterResistance = watch.WaterResistance,
                Warranty = watch.Warranty,
                Category = watch.CurrentCategory
            };
        }
        
    }
}