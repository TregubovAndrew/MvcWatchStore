using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WatchStore.BusinessLogic.Interfaces;

namespace WatchStoreWeb.Controllers
{
    public class BrandController : Controller
    {
        private readonly IBrandService _brandService;

        public BrandController(IBrandService brandService)
        {
            _brandService = brandService;
        }

        // GET: Brand
        public ActionResult Index()
        {
            return View(_brandService.GetAllBrands());
        }
    }
}