using System.Collections.Generic;
using System.Linq;
using WatchStore.DataAccess.Entities;

namespace WatchStore.DataAccess.Session
{
    public class Cart
    {
        private List<CartLine> _cartLines = new List<CartLine>();

        public void AddItem(Watch watch, int quantity)
        {
            var line = _cartLines.FirstOrDefault(p => p.Watch.Id == watch.Id);
            if (line == null)
            {
                _cartLines.Add(new CartLine
                {
                    Watch = watch,
                    Quantity = quantity
                });
            }
            else
            {
                line.Quantity += quantity;
            }

        }

        public void RemoveItem(Watch watch)
        {
            _cartLines.RemoveAll(w => w.Watch.Id==watch.Id);
        }

        public decimal ComputeTotalPrice()
        {
            return _cartLines.Sum(w => w.Watch.Price * w.Quantity);
        }

        public IEnumerable<CartLine> CartLines()
        {
            return _cartLines;
        }

        public void Clear()
        {
            _cartLines.Clear();
        }
    }
}
