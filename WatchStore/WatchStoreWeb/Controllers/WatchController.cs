using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WatchStore.BusinessLogic.Interfaces;
using WatchStore.DataAccess.Entities;
using WatchStore.DataAccess.Interfaces;
using WatchStore.DataAccess.Repositories;
using WatchStoreWeb.Models;

namespace WatchStoreWeb.Controllers
{
    public class WatchController : Controller
    {
        // GET: Watch
        private readonly IWatchService _watchService;
        private readonly IImageService _imageService;
        private readonly IOrderService _orderService;
        public WatchController(IWatchService watchService, IImageService imageService, IOrderService orderService)
        {
            _watchService = watchService;
            _imageService = imageService;
            _orderService = orderService;
        }

        // GET: Watches
        public ActionResult Index(string category,string searchTerm = null)
        {
            var watches = _watchService.SearchByName(searchTerm).Select(WatchModel.ConvertToWatchModel).Where(c => category == null || c.Category == category);
            //var watches = _watchService.GetAllWatches(w =>w.)

            //var model = watches.Where(w => searchTerm==null || w.Name.StartsWith(searchTerm)).Select(WatchModel.ConvertToWatchModel);
            return View(watches);
        }
        
        public ActionResult WatchDetails(int id,string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            var watch = _watchService.GetById(id);
            WatchModel model = WatchModel.ConvertToWatchModel(watch);
            return View(model);
        }
        // GET: Watches/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Watch watch = _watchService.GetById(id);
            if (watch == null)
            {
                return HttpNotFound();
            }
            return View(WatchModel.ConvertToWatchModel(watch));
        }

        // GET: Watches/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Watches/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
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

        // GET: Watches/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Watch watch = _watchService.GetById(id);
            if (watch == null)
            {
                return HttpNotFound();
            }
            return View(WatchModel.ConvertToWatchModel(watch));
        }

        // POST: Watches/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(WatchModel watchModel, HttpPostedFileBase file)
        {
            if (ModelState.IsValid && file!=null)
            { 
                Watch watch = WatchModel.ConvertToWatch(watchModel);

                _watchService.EditWatch(watch);
                _imageService.AddImage(_imageService.ConvertFileToImageDataAndBind(file, watch));
                //var image = _imageService.ConvertFileToImageDataAndBind(file, watch);

                return RedirectToAction("Index");
            }
            if (file == null)
                return RedirectToAction("Edit", "Watch", new { id = watchModel.Id });
            return View(watchModel);
        }

        // GET: Watches/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Watch watch = _watchService.GetById(id);
            if (watch == null)
            {
                return HttpNotFound();
            }
            return View(WatchModel.ConvertToWatchModel(watch));
        }

        // POST: Watches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
           _watchService.DeleteWatch(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {

            }
            base.Dispose(disposing);
        }

     
       
    }
}