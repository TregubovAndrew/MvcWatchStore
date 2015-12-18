using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ninject.Infrastructure.Language;
using WatchStore.BusinessLogic.Interfaces;
using WatchStore.BusinessLogic.Session;
using WatchStore.DataAccess.Entities;
using WatchStore.DataAccess.Interfaces;
using WatchStore.DataAccess.Session;
using WatchStoreWeb.Models;

namespace WatchStoreWeb.Controllers
{
    public class CartController : Controller
    {
        private readonly IWatchService _watchService;
        private readonly IOrderService _orderService;

        public CartController(IWatchService watchService, IOrderService orderService)
        {
            _watchService = watchService;
            _orderService = orderService;
        }

        public ActionResult Index(string returnUrl)
        {
            //var watches =
            //    _watchService.GetAllWatches().Where(w => w.Id == GetAnotherCart().GetAllWatchIds().FirstOrDefault());
            return View(new CartModel { Cart = GetCart(), ReturnUrl = returnUrl });
        }
        // GET: Cart
        [HttpPost]
        public ActionResult AddToCart(int id, string returnUrl)
        {
            var watch = _watchService.GetById(id);
            if (watch != null)
            {
                GetCart().AddItem(watch, 1);
                //GetAnotherCart().AddWatchId(watch);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        public ActionResult RemoveFromCart(int id, string returnUrl)
        {
            var watch = _watchService.GetById(id);
            if (watch != null)
            {
                GetCart().RemoveItem(watch);
                //GetAnotherCart().RemoveWatchId(watch);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        public ActionResult Summary()
        {
            //var watches =
            //    _watchService.GetAllWatches().Where(w => w.Id == GetAnotherCart().GetAllWatchIds().FirstOrDefault());
            //return PartialView(watches);
            return PartialView(GetCart());
        }
        public ActionResult CheckOut()
        {
            return View(new OrderModel());
        }

        [HttpPost]
        public ActionResult CheckOut(OrderModel model)
        {
            if (ModelState.IsValid)
            {
                if (!GetCart().CartLines().Any())
                {
                    ModelState.AddModelError("", "Sorry your cart is empty");
                }
                else
                {

                    Order order = OrderModel.ConvertToOrder(model);
                    _orderService.MakeOrder(order);
                    foreach (var item in GetCart().CartLines())
                    {
                        var watch = _watchService.GetById(item.Watch.Id);
                        _orderService.MakeDependency(order, watch, item.Quantity);
                    }
                    //foreach (var id in GetAnotherCart().GetAllWatchIds())
                    //{
                    //    var watch = _watchService.GetById(id);
                    //    model.Watches.Add(watch);

                    //}
                    GetCart().Clear();
                    return View("Completed");
                }
            }
            return View(model);
        }

        private Cart GetCart()
        {
            var cart = (Cart)Session["Cart"];
            if (cart == null)
            {
                cart = new Cart();
                Session["Cart"] = cart;
            }
            return cart;
        }

        private AnotherCart GetAnotherCart()
        {
            var cart = (AnotherCart)Session["AnotherCart"];
            if (cart == null)
            {
                cart = new AnotherCart(_watchService);
                Session["AnotherCart"] = cart;
            }
            return cart;
        }
    }
}