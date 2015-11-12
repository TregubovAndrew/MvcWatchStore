using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using WatchStore.DataAccess.Entities;

namespace WatchStore.BusinessLogic.Interfaces
{
    public interface IImageService
    {
        Image GetById(int? id);
        IEnumerable<Image> GetAllImages();
        IEnumerable<Image> GetImagesByWatchId(int watchId);
        int AmountOfImages(int watchId);
        void AddImage(Image image);
        void EditImage(Image image);
        void DeleteImage(int? id);

        Image ConvertFileToImageDataAndBind(HttpPostedFileBase file,Watch watch);
    }
}
