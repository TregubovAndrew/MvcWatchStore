using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using WatchStore.DataAccess.Entities;

namespace WatchStore.DataAccess.Interfaces
{
    public interface IImageRepository
    {
        Image GetById(int? id);
        IEnumerable<Image> GetAllImages();
        IEnumerable<Image> GetImagesByWatchId(int watchId);
        int AmountOfImages(int watchId);
        void AddImage(Image image);
        void EditImage(Image image);
        void DeleteImage(int? id);
    }
}
