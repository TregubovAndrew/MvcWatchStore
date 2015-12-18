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
        private readonly IImageRepository _imageRepository;

        public ImageService(IImageRepository imageRepository)
        {
            _imageRepository = imageRepository;
        }

        public Image GetById(int? id)
        {
            return _imageRepository.GetById(id);
        }

        public IEnumerable<Image> GetAllImages()
        {
            return _imageRepository.GetAllImages();
        }

        public IEnumerable<Image> GetImagesByWatchId(int watchId)
        {
            return _imageRepository.GetImagesByWatchId(watchId);
        }

        public int AmountOfImages(int watchId)
        {
            return _imageRepository.AmountOfImages(watchId);
        }

        public void AddImage(Image image)
        {
            _imageRepository.AddImage(image);
        }

        public void EditImage(Image image)
        {
            _imageRepository.EditImage(image);
        }

        public void DeleteImage(int? id)
        {
            _imageRepository.DeleteImage(id);
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
