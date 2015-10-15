using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WatchStore.DataAccess.Repositories;


namespace WatchStore.Web.Controllers
{
    public class HomeController : Controller
    {
        WatchStoreDataContext _db = new WatchStoreDataContext();
        public ActionResult Index()
        {
            return View();
            //_db.Watches.ToList();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}