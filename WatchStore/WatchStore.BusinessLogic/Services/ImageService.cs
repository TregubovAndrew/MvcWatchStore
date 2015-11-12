using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using WatchStore.BusinessLogic.Interfaces;
using WatchStore.DataAccess.Entities;
using WatchStore.DataAccess.Interfaces;

namespace WatchStore.BusinessLogic.Services
{
    public class ImageService : IImageService
    {
        private readonly IImageRepository _repository;

        public ImageService(IImageRepository repository)
        {
            _repository = repository;
        }

        public Image GetById(int? id)
        {
            return _repository.GetById(id);
        }

        public IEnumerable<Image> GetAllImages()
        {
            return _repository.GetAllImages();
        }

        public IEnumerable<Image> GetImagesByWatchId(int watchId)
        {
            return _repository.GetImagesByWatchId(watchId);
        }

        public int AmountOfImages(int watchId)
        {
            return _repository.AmountOfImages(watchId);
        }

        public void AddImage(Image image)
        {
            _repository.AddImage(image);
        }

        public void EditImage(Image image)
        {
            _repository.EditImage(image);
        }

        public void DeleteImage(int? id)
        {
            _repository.DeleteImage(id);
        }

        public Image ConvertFileToImageDataAndBind(HttpPostedFileBase file,Watch watch)
        {
            Image image = new Image();
            image.FileName = file.FileName;
            image.ImageSize = file.ContentLength;
            byte[] data = new byte[image.ImageSize];
            file.InputStream.Read(data, 0, image.ImageSize);
            image.ImageData = data;
            image.WatchId = watch.Id;
            return image;
        }
    }
}
