using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchStore.DataAccess.Entities;

namespace WatchStore.DataAccess.Interfaces
{
    public interface IWatchRepository
    {
        Watch GetById(int? id);
        IEnumerable<Watch> GetAllWatches();
        Watch GetByName(string name);
        void CreateWatch(Watch watch);
        void EditWatch(Watch watch);
        void DeleteWatch(int? id);
        void Dispose();
        IEnumerable<Watch> SearchByName(string name);

    }



}
