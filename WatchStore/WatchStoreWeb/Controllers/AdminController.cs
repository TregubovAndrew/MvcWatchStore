using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using AutoMapper;
using WatchStore.BusinessLogic.Interfaces;
using WatchStore.DataAccess.Entities;
using WatchStoreWeb.Models;

namespace WatchStoreWeb.Controllers
{
    //[Authorize(Users = "Admin")]
    public class AdminController : Controller
    {
        // GET: Admin
        private readonly IWatchService _watchService;
        private readonly IImageService _imageService;
        private readonly IOrderService _orderService;

        public AdminController(IWatchService watchService, IImageService imageService, IOrderService orderService)
        {
            _watchService = watchService;
            _imageService = imageService;
            _orderService = orderService;
        }

        public ActionResult Index()
        {
            var watches = _watchService.GetAllWatches().Select(item => Mapper.Map<Watch, WatchModel>(item));
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
            return View(Mapper.Map<Watch, WatchModel>(watch));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(WatchModel watchModel, HttpPostedFileBase file)
        {
            if (ModelState.IsValid && file != null)
            {
                Watch watch = Mapper.Map<WatchModel, Watch>(watchModel);

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
                Watch watch = Mapper.Map<WatchModel, Watch>(watchModel);
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
            return RedirectToAction("Edit", "Admin", new { id });
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int? id)
        {
            var watch = _watchService.GetById(id);
            if (watch != null)
            {
                _watchService.DeleteWatch(id);
                TempData["message"] = string.Format("{0} was deleted", watch.Name);
            }

            return RedirectToAction("Index");
        }

        public ActionResult GetAllOrders()
        {
            var orders = _orderService.GetAllOrders().Select(OrderModel.ConvertToOrderModel);
            return View(orders);
        }

        public ActionResult EditOrder(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var order = _orderService.GetById(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(OrderModel.ConvertToOrderModel(order));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditOrder(OrderModel orderModel)
        {
            if (ModelState.IsValid)
            {
                Order order = OrderModel.ConvertToOrder(orderModel);
                _orderService.EditOrder(order);
                ViewBag.Message = "has been saved";
                TempData["message"] = string.Format("{0} has been saved", order.Id);

                return RedirectToAction("GetAllOrders");
            }
            return View(orderModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteOrder(int id)
        {
            var order = _orderService.GetById(id);
            if (order != null)
            {
                _orderService.RemoveOrder(id);
                
                TempData["message"] = string.Format("{0} was deleted", order.Id);
            }

            return RedirectToAction("GetAllOrders");
        }

        [HttpGet]
        public ActionResult WatchesInOrder(int id)
        {
            var order = _orderService.GetById(id);
            var watches = order.OrderWatches.ToList();
            ViewBag.orderId = id;
            var watchesInOrder = watches.Select(item => new WatchesInOrderModel
            {
                Watch = item.Watch,
                Quantity = item.Quantity,
                OrderId = order.Id
            });
            return View(watchesInOrder);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RemoveWatchesFromOrder(int orderId, int watchId)
        {
            var order = _orderService.GetById(orderId);
            _orderService.RemoveDependency(_orderService.GetById(orderId), _watchService.GetById(watchId), 0);
            order.Sum = _orderService.CalculateTotalSum(orderId);
            _orderService.EditOrder(order);
            return RedirectToAction("WatchesInOrder", new { id = orderId });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult IncreaseNumberOfWatchesInOrderByOne(int orderId, int watchId)
        {
            var order = _orderService.GetById(orderId);
            _orderService.IncreaseQuantityByOne(orderId,watchId);
            order.Sum = _orderService.CalculateTotalSum(orderId);
            _orderService.EditOrder(order);
            return RedirectToAction("WatchesInOrder", new { id = orderId });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DecreaseNumberOfWatchesInOrderByOne(int orderId, int watchId)
        {
            var order = _orderService.GetById(orderId);
            _orderService.DecreaseQuantityByOne(orderId,watchId);
            order.Sum = _orderService.CalculateTotalSum(orderId);
            _orderService.EditOrder(order);
            return RedirectToAction("WatchesInOrder", new { id = orderId });
        }
    }
}