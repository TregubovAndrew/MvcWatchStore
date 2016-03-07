using System.Collections.Generic;
using WatchStore.DataAccess.Entities;

namespace WatchStore.BusinessLogic.Interfaces
{
    public interface IBrandService
    {
        Brand GetById(int? id);

        IEnumerable<Brand> GetAllBrands();

        Brand GetByName(string name);

        void CreateBrand(Brand brand);

        void EditBrand(Brand brand);

        void DeleteBrand(int? id);

        IEnumerable<Watch> GetAllWatchesByBrand(int brandId);
    }
}
