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
    public class WatchRepository : IWatchRepository
    {
        private readonly WatchStoreDataContext db = new WatchStoreDataContext();
        public Watch GetById(int? id)
        {
            return db.Watches.Find(id);
        }

        public IEnumerable<Watch> GetAllWatches()
        {
            return db.Watches;
        }

        public Watch GetByName(string name)
        {
            return db.Watches.FirstOrDefault(watch => watch.Name == name);
        }

        public void CreateWatch(Watch watch)
        {
            db.Watches.Add(watch);
            db.SaveChanges();
        }

        public void EditWatch(Watch watch)
        {
            db.Entry(watch).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void DeleteWatch(int? id)
        {
            Watch watch = db.Watches.Find(id);
            db.Watches.Remove(watch);
            db.SaveChanges();
        }

        public void Dispose()
        {
           db.Dispose();
        }

        public IEnumerable<Watch> SearchByName(string name)
        {
            return  name==null ? db.Watches : db.Watches.Where(w => w.Name.StartsWith(name));
        }
    }
}
