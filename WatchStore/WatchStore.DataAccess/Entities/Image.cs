using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace WatchStore.DataAccess.Entities
{
    public class Image
    {
        public int Id { get; set; }
        public int ImageSize { get; set; }
        public string FileName { get; set; }
        public byte[] ImageData { get; set; }
        [NotMapped]
        public HttpPostedFileBase File { get; set; }
        public int? WatchId { get; set; }
        public virtual Watch Watch { get; set; }
    }
}
