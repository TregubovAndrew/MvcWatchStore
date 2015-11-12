using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WatchStore.BusinessLogic.Interfaces;
using WatchStore.BusinessLogic.Services;
using WatchStore.DataAccess;
using WatchStore.DataAccess.Entities;

namespace WatchStoreWeb.Controllers
{
    public class ImageController : Controller
    {
        // GET: Image
        private readonly IImageService _imageService;

        public ImageController(IImageService imageService)
        {
            _imageService = imageService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var model = _imageService.GetAllImages();
            if(model==null)
                return new HttpNotFoundResult();
            return View(model);
        }


        public ActionResult Upload()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Upload(Image image)
        {
            image.FileName = image.File.FileName;
            image.ImageSize = image.File.ContentLength;
            byte[] data = new byte[image.ImageSize];
            image.File.InputStream.Read(data, 0, image.ImageSize);
            image.ImageData = data;
            _imageService.AddImage(image);
            return RedirectToAction("Index");
        }
    }
}