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
        private readonly IWatchRepository _repository;
        public WatchService(IWatchRepository repository)
        {
            _repository = repository;
        }

        public Watch GetById(int? id)
        {
            return _repository.GetById(id);
        }

        public IEnumerable<Watch> GetAllWatches()
        {
            return _repository.GetAllWatches();
        }

        public Watch GetByName(string name)
        {
            return _repository.GetByName(name);
        }

        public void CreateWatch(Watch watch)
        {
            _repository.CreateWatch(watch);
        }

        public void EditWatch(Watch watch)
        {
           _repository.EditWatch(watch);
        }

        public void DeleteWatch(int? id)
        {
           _repository.DeleteWatch(id);
        }

        public IEnumerable<Watch> GetWatchesByCategory(string category)
        {
            return _repository.GetAllWatches().Where(c => category == null || c.Category == category);
        }
        public IEnumerable<Watch> SearchByName(string name)
        {
            return _repository.SearchByName(name);
        }
    }
}
