using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchStore.BusinessLogic.Interfaces;
using WatchStore.DataAccess.Entities;

namespace WatchStore.BusinessLogic.Session
{
    public class AnotherCart
    {
        private readonly IWatchService _watchService;
        private readonly List<int> _watchIds = new List<int>();

        public AnotherCart(IWatchService watchService)
        {
            _watchService = watchService;
        }

        public void AddWatchId(Watch watch)
        {
            var instance = _watchService.GetAllWatches().FirstOrDefault(w => w.Id == watch.Id);
            if (instance != null)
                _watchIds.Add(instance.Id);
        }

        public void RemoveWatchId(Watch watch)
        {
            _watchIds.RemoveAll(w => w == watch.Id);
        }

        public List<int> GetAllWatchIds()
        {
            return _watchIds;
        }

        public void Clear()
        {
            _watchIds.Clear();
        }
    }

}
