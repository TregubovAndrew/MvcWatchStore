using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WatchStore.BusinessLogic.Interfaces;
using WatchStore.DataAccess.Entities;
using WatchStoreWeb.Models;

namespace WatchStoreWeb.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        private readonly IWatchService _watchService;
        private readonly IImageService _imageService;

        public AdminController(IWatchService watchService, IImageService imageService)
        {
            _watchService = watchService;
            _imageService = imageService;
        }

        public ActionResult Index()
        {
            var watches = _watchService.GetAllWatches().Select(WatchModel.ConvertToWatchModel);
            return View(watches);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var watch = _watchService.GetById(id);
            if (watch == null)
            {
                return HttpNotFound();
            }
            return View(WatchModel.ConvertToWatchModel(watch));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(WatchModel watchModel, HttpPostedFileBase file)
        {
            if (ModelState.IsValid && file != null)
            {
                Watch watch = WatchModel.ConvertToWatch(watchModel);

                _watchService.EditWatch(watch);
                _imageService.AddImage(_imageService.ConvertFileToImageDataAndBind(file, watch));
                ViewBag.Message = "has been saved";
                TempData["message"] = string.Format("{0} has been saved", watch.Name);

                return RedirectToAction("Index");
            }
            //if (file == null)
            //    return RedirectToAction("Edit", "Watch", new { id = watchModel.Id });
            return View(watchModel);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(WatchModel watchModel, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                Watch watch = WatchModel.ConvertToWatch(watchModel);
                _watchService.CreateWatch(watch);
                var image = _imageService.ConvertFileToImageDataAndBind(file, watch);
                _imageService.AddImage(image);
                return RedirectToAction("Index");
            }

            return View(watchModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteImage(int id, int imageId)
        {
           _imageService.DeleteImage(imageId);
            //_watchService.DeleteWatch(id);
           return RedirectToAction("Edit", "Admin", new {id });
        }
    }
}