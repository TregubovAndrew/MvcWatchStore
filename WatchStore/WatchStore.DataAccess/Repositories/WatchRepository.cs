using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.ModelBinding;
using WatchStore.DataAccess.Entities;
using WatchStore.DataAccess.Interfaces;

namespace WatchStore.DataAccess.Repositories
{
    public class WatchRepository : IWatchRepository, IDisposable
    {
        private readonly WatchStoreDataContext _db = new WatchStoreDataContext();
        public Watch GetById(int? id)
        {
            return _db.Watches.Find(id);
        }

        public IEnumerable<Watch> GetAllWatches()
        {
            return _db.Watches;
        }

        public Watch GetByName(string name)
        {
            return _db.Watches.FirstOrDefault(watch => watch.Name == name);
        }

        public void CreateWatch(Watch watch)
        {
            _db.Watches.Add(watch);
            _db.SaveChanges();
        }

        public void EditWatch(Watch watch)
        {
            _db.Entry(watch).State = EntityState.Modified;
            _db.SaveChanges();
        }

        public void DeleteWatch(int? id)
        {
            Watch watch = _db.Watches.Find(id);
            _db.Watches.Remove(watch);
            _db.SaveChanges();
        }

        public void Dispose()
        {
           _db.Dispose();
        }

        public IEnumerable<Watch> SearchByName(string name)
        {
            return  name==null ? _db.Watches : _db.Watches.Where(w => w.Name.StartsWith(name));
        }

       
    }
}
