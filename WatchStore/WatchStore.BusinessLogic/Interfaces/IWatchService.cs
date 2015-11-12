using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchStore.DataAccess.Entities;

namespace WatchStore.BusinessLogic.Interfaces
{
    public interface IWatchService
    {
        Watch GetById(int? id);
        IEnumerable<Watch> GetAllWatches();
        Watch GetByName(string name);
        void CreateWatch(Watch watch);
        void EditWatch(Watch watch);
        void DeleteWatch(int? id);
        IEnumerable<Watch> GetWatchesByCategory(string category);
        IEnumerable<Watch> SearchByName(string name);
    }
}
