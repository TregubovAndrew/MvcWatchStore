using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WatchStore.BusinessLogic.Interfaces;
using WatchStore.DataAccess.Entities;
using WatchStore.DataAccess.Interfaces;
using WatchStoreWeb.Models;

namespace WatchStoreWeb.Controllers
{
    public class NavController : Controller
    {
        // GET: Nav
        private readonly IWatchService _watchService;
        private readonly IAccountService _accountService;

        public NavController(IWatchService watchService, IAccountService accountService)
        {
            _watchService = watchService;
            _accountService = accountService;
        }


        public PartialViewResult Menu(string category = null)
        {
            @ViewBag.SelectedCategory = category;
            return PartialView();
        }

        public PartialViewResult AdminMenu()
        {
            return PartialView();
        }

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult WatchSearch()
        {
            var watches = _watchService.GetAllWatches().Select(x => new {x.Name,x.Price});
            var accs = _accountService.GetAllAccount().Select(x => new {x.FirstName,x.LastName});
            return Json(watches, JsonRequestBehavior.AllowGet);
        }
    }
}