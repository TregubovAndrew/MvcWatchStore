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
   
    public class BrandService : IBrandService
    {
        private readonly IBrandRepository _brandRepository;

        public BrandService(IBrandRepository brandRepository)
        {
            _brandRepository = brandRepository;
        }

        public Brand GetById(int? id)
        {
            return _brandRepository.GetById(id);
        }

        public IEnumerable<Brand> GetAllBrands()
        {
            return _brandRepository.GetAllBrands();
        }

        public Brand GetByName(string name)
        {
            return _brandRepository.GetByName(name);
        }

        public void CreateBrand(Brand brand)
        {
            _brandRepository.CreateBrand(brand);
        }

        public void EditBrand(Brand brand)
        {
            _brandRepository.EditBrand(brand);
        }

        public void DeleteBrand(int? id)
        {
            _brandRepository.DeleteBrand(id);
        }

        public IEnumerable<Watch> GetAllWatchesByBrand(int brandId)
        {
            return _brandRepository.GetById(brandId).Watches;
        }
    }
}
