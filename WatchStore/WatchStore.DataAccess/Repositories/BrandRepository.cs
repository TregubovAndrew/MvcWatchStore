using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using WatchStore.DataAccess.Entities;
using WatchStore.DataAccess.Interfaces;

namespace WatchStore.DataAccess.Repositories
{
    public class BrandRepository : IBrandRepository
    {
        private readonly WatchStoreDataContext _db;

        public BrandRepository(WatchStoreDataContext db)
        {
            _db = db;
        }

        public Brand GetById(int? id)
        {
            return _db.Brands.Find(id);
        }

        public IEnumerable<Brand> GetAllBrands()
        {
            return _db.Brands;
        }

        public Brand GetByName(string name)
        {
            return _db.Brands.FirstOrDefault(b => b.Name == name);
        }

        public void CreateBrand(Brand brand)
        {
            _db.Brands.Add(brand);
            _db.SaveChanges();
        }

        public void EditBrand(Brand brand)
        {
            _db.Entry(brand).State = EntityState.Modified;
            _db.SaveChanges();
        }

        public void DeleteBrand(int? id)
        {
            Brand brand = _db.Brands.Find(id);
            //foreach (var image in watch.Images.ToList())
            //{
            //    _db.Images.Remove(image);
            //    _db.SaveChanges();
            //}
            _db.Brands.Remove(brand);
            _db.SaveChanges();
        }
    }
}
