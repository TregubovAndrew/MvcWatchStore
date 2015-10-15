using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.WebPages;
using WatchStore.DataAccess.Entities;
using WatchStore.DataAccess.Interfaces;
using WatchStore.DataAccess.Repositories;
using WatchStore.Web.Models;

namespace WatchStore.Web.Controllers
{
    public class WatchesController : Controller
    {
        private readonly IWatchRepository _repository;

        public WatchesController(IWatchRepository repo)
        {
            _repository = repo;
        }

        // GET: Watches
        public ActionResult Index(string searchTerm = null)
        {
            //var models = repository.Watches

            var watches = _repository.SearchByName(searchTerm).Select(WatchModel.ConvertToWatchModel);

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
        public ActionResult Create([Bind(Include = "Id,Name,Brand,Colour,WaterResistance,Warranty")] Watch watch)
        {
            if (ModelState.IsValid)
            {
                _repository.CreateWatch(watch);
                return RedirectToAction("Index");
            }

            return View(WatchModel.ConvertToWatchModel(watch));
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
        public ActionResult Edit([Bind(Include = "Id,Name,Brand,Colour,WaterResistance,Warranty")] Watch watch)
        {
            if (ModelState.IsValid)
            {
                _repository.EditWatch(watch);
                return RedirectToAction("Index");
            }
            return View(WatchModel.ConvertToWatchModel(watch));
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
            _repository.DeleteWatch(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _repository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
