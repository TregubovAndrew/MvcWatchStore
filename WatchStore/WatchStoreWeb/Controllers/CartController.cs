using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Mail;
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
        private readonly IUserService _userService;

        public CartController(IWatchService watchService, IOrderService orderService, IUserService userService)
        {
            _watchService = watchService;
            _orderService = orderService;
            _userService = userService;
        }

        public ActionResult Index(string returnUrl)
        {
            //var watches =
            //    _watchService.GetAllWatches().Where(w => w.Id == GetAnotherCart().GetAllWatchIds().FirstOrDefault());
            ViewBag.Url = returnUrl;
            return View(new CartModel { Cart = GetCart()});
        }
        // GET: Cart
        [HttpPost]
        public ActionResult AddToCart(int id,string returnUrl)
        {
            ViewBag.Url = returnUrl;
            var watch = _watchService.GetById(id);
            if (watch != null)
            {
                GetCart().AddItem(watch, 1);
                //GetAnotherCart().AddWatchId(watch);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        public ActionResult RemoveFromCart(int id)
        {
            var watch = _watchService.GetById(id);
            if (watch != null)
            {
                GetCart().RemoveItem(watch);
                //GetAnotherCart().RemoveWatchId(watch);
            }
            return RedirectToAction("Index");
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
            var user = (Customer)_userService.GetCurrentUser();
            if (user != null)
            {
                var model = new OrderModel
                {
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    PostalCode = user.PostalCode,
                    Country = user.Country,
                    City = user.City,
                    Address = user.Address,
                    Phone = user.Phone
                };
                return View(model);
            }
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
                    order.Sum = GetCart().ComputeTotalPrice();
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


                    var message = new MailMessage();
                    message.To.Add(new MailAddress(order.Email));  // replace with valid value 
                    message.From = new MailAddress("manick1523@gmail.com");  // replace with valid value
                    message.Subject = String.Format("Order №{0}", order.Id);
                    var watchesInOrder = order.OrderWatches.ToList();
                    var details = "<table class='table'>" +
                     "<thead>" +
                     "<tr>" +
                     "<th>Quantity</th>" +
                     "<th>Name</th>" +
                     "<th>Price</th>" +
                     "<th>SubTotal</th>" +
                     "</tr>" +
                     "</thead>" +
                     "<tbody>";
                    foreach (var item in watchesInOrder)
                    {
                        details += "<tr>" +
                                    "<td>" + item.Quantity + "</td>" +
                                    "<td>" + item.Watch.Name + "</td>" +
                                    "<td>" + item.Watch.Price + "</td>" +
                                    "<td>" + item.Watch.Price * item.Quantity + "</td>" +
                                   "</tr>";
                    }
                    details += "</tbody>";
                    details += "<tfoot>" +
                                "<tr>" +
                                 "<td>" + order.Sum + "</td>" +
                                "</tr>" +
                               "</tfoot>";
                    details += "</table>";
                    message.Body = String.Format("<p>Dear {0}</p>" +
                                                 "We thank you for your order.The order is in process of execution and it will be dispatched soon" +
                                                 "{1}", model.FirstName, details);
                    message.IsBodyHtml = true;

                    using (var smtp = new SmtpClient())
                    {
                        var credential = new NetworkCredential
                        {
                            UserName = "email", // replace with valid value
                            Password = "password" // replace with valid value
                        };
                        smtp.UseDefaultCredentials = false;
                        smtp.Credentials = credential;
                        smtp.Host = "smtp.gmail.com";
                        smtp.Port = 587;
                        smtp.EnableSsl = true;
                        smtp.Send(message);

                    }
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