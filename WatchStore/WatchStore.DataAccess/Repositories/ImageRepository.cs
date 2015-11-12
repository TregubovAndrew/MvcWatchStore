using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchStore.DataAccess.Entities;
using WatchStore.DataAccess.Interfaces;

namespace WatchStore.DataAccess.Repositories
{
    public class ImageRepository : IImageRepository, IDisposable
    {
        private readonly WatchStoreDataContext _db = new WatchStoreDataContext();
        public Image GetById(int? id)
        {
            return _db.Images.Find(id);
        }

        public IEnumerable<Image> GetAllImages()
        {
            return _db.Images;
        }

        public IEnumerable<Image> GetImagesByWatchId(int watchId)
        {
            return _db.Images.Where(i => i.WatchId == watchId);
        }

        public int AmountOfImages(int watchId)
        {
            return _db.Images.Count(i => i.WatchId == watchId);
        }

        public void AddImage(Image image)
        {
            _db.Images.Add(image);
            _db.SaveChanges();
        }

        public void EditImage(Image image)
        {
            _db.Entry(image).State = EntityState.Added;
            _db.SaveChanges();
        }

        public void DeleteImage(int? id)
        {
            Image image = _db.Images.Find(id);
            _db.Images.Remove(image);
            _db.SaveChanges();
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}
