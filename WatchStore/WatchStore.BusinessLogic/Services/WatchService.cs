using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchStore.BusinessLogic.Interfaces;
using WatchStore.DataAccess.Entities;
using WatchStore.DataAccess.Interfaces;

namespace WatchStore.BusinessLogic.Services
{
    public class WatchService : IWatchService
    {
        private readonly IWatchRepository _watchRepository;
        private readonly IOrderWatchRepository _orderWatchRepository;
        public WatchService(IWatchRepository watchRepository, IOrderWatchRepository orderWatchRepository)
        {
            _watchRepository = watchRepository;
            _orderWatchRepository = orderWatchRepository;
        }

        public Watch GetById(int? id)
        {
            return _watchRepository.GetById(id);
        }

        public IEnumerable<Watch> GetAllWatches()
        {
            return _watchRepository.GetAllWatches();
        }

        public Watch GetByName(string name)
        {
            return _watchRepository.GetByName(name);
        }

        public void CreateWatch(Watch watch)
        {
            _watchRepository.CreateWatch(watch);
        }

        public void EditWatch(Watch watch)
        {
            _watchRepository.EditWatch(watch);
        }

        public void DeleteWatch(int? id)
        {
            _watchRepository.DeleteWatch(id);
        }

        public IEnumerable<Watch> GetWatchesByCategory(string category)
        {
            return _watchRepository.GetAllWatches().Where(c => category == null || c.Category == category);
        }
        public IEnumerable<Watch> SearchByName(string name)
        {
            return _watchRepository.SearchByName(name);
        }

        public IEnumerable<Watch> GetAllWatchesInOrder(int orderId)
        {
            return _watchRepository.GetAllWatches();
        }
    }
}
