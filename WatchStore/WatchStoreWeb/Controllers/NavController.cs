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

        public NavController(IWatchService watchService)
        {
            _watchService = watchService;
        }


        public PartialViewResult Menu(string category = null)
        {
            @ViewBag.SelectedCategory = category;
            //IEnumerable<WatchModel> watchesCategory = _watchService.GetAllWatches().Select(WatchModel.ConvertToWatchModel).Distinct().OrderBy(c =>c).Where(c => category==null || c.CurrentCategory==category);
            IEnumerable<string> categories =
                _watchService.GetAllWatches().Select(c => c.Category).Distinct().OrderBy(c => c);
            return PartialView(categories);
        }
    }
}