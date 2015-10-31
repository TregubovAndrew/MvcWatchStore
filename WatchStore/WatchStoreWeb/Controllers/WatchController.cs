using System;
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
        private readonly IWatchService _repository;
        public WatchController(IWatchService repository)
        {
            _repository = repository;
        }

        // GET: Watches
        public ActionResult Index(string searchTerm = null,string category = null)
        {
            //var models = repository.Watches

            var watches = _repository.SearchByName(searchTerm).Select(WatchModel.ConvertToWatchModel).Where(c => category==null || c.CurrentCategory==category);

            //var model = watches.Where(w => searchTerm==null || w.Name.StartsWith(searchTerm)).Select(WatchModel.ConvertToWatchModel);
            return View(watches);
        }
        // GET: Watches/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Watch watch = _repository.GetById(id);
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
        public ActionResult Create([Bind(Include = "Id,Name,Brand,Colour,WaterResistance,Warranty")] WatchModel watchModel)
        {
            if (ModelState.IsValid)
            {
                using (var db = new WatchRepository())
                {
                    db.CreateWatch(WatchModel.ConvertToWatch(watchModel));
                }
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
            Watch watch = _repository.GetById(id);
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
        public ActionResult Edit([Bind(Include = "Id,Name,Brand,Colour,WaterResistance,Warranty")] WatchModel watchModel)
        {
            if (ModelState.IsValid)
            {
                using (var db = new WatchRepository())
                {
                    db.EditWatch(WatchModel.ConvertToWatch(watchModel));
                }
                return RedirectToAction("Index");
            }
            return View(watchModel);
        }

        // GET: Watches/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Watch watch = _repository.GetById(id);
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
            using (var db = new WatchRepository())
            {
                db.DeleteWatch(id);
            }
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