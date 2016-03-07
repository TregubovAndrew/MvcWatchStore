using System.Collections;
using System.Collections.Generic;

namespace WatchStore.DataAccess.Entities
{
    public class Brand
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public virtual ICollection<Watch> Watches { get; set; }

    }
}
