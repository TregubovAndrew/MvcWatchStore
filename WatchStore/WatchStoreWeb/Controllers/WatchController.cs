using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using WatchStore.BusinessLogic;
using WatchStore.BusinessLogic.Interfaces;
using WatchStore.DataAccess.Entities;
using WatchStore.DataAccess.Interfaces;
using WatchStore.DataAccess.Repositories;
using WatchStoreWeb.Helpers;
using WatchStoreWeb.Models;

namespace WatchStoreWeb.Controllers
{
    public class WatchController : Controller
    {
        // GET: Watch
        private readonly IWatchService _watchService;
        private readonly IImageService _imageService;
        private readonly IOrderService _orderService;
        private readonly IRequestContext _requestContext;

        public WatchController(IWatchService watchService, IImageService imageService, IOrderService orderService, IRequestContext requestContext)
        {
            _watchService = watchService;
            _imageService = imageService;
            _orderService = orderService;
            _requestContext = requestContext;
        }

        // GET: Watches
        public ActionResult Index(string category, bool? isNew)
        {
            var watches = _watchService.GetAllWatches().Select(item => Mapper.Map<Watch, WatchModel>(item)).Where(c => category == null || c.Category == category);
            var test = _watchService.GetAllWatches();
            if (isNew==true)
            {
                watches = watches.OrderByDescending(x => x.Id);
            }
            //var watches = _watchService.GetAllWatches(w =>w.)
            var user = _requestContext.User;
            //var model = Mapper.Map<IEnumerable<Watch>, IEnumerable<WatchModel>>(watches);
            //var model = watches.Where(w => searchTerm==null || w.Name.StartsWith(searchTerm)).Select(WatchModel.ConvertToWatchModel);
            return View(watches);
        }

        public ActionResult DynamicSearch(string searchTerm)
        {
            var watches = _watchService.GetAllWatches().Select(x => x.Name.ToLower()).Contains(searchTerm);
            return Json(watches, JsonRequestBehavior.AllowGet);
        }

        public ActionResult WatchDetails(int id)
        {
            var watch = _watchService.GetById(id);
            WatchModel model = Mapper.Map<Watch, WatchModel>(watch); //WatchModel.ConvertToWatchModel(watch);
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
            return View(Mapper.Map<Watch,WatchModel>(watch));
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
                Watch watch = Mapper.Map<WatchModel,Watch>(watchModel);
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
            return View(Mapper.Map<Watch, WatchModel>(watch));
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
                Watch watch = Mapper.Map<WatchModel, Watch>(watchModel);

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
            return View(Mapper.Map<Watch, WatchModel>(watch));
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