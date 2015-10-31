using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WatchStore.BusinessLogic.Interfaces;
using WatchStore.BusinessLogic.Services;
using WatchStore.DataAccess.Entities;
using WatchStore.DataAccess.Interfaces;
using WatchStore.DataAccess.Repositories;
using WatchStoreWeb.Models;

namespace WatchStoreWeb.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }


        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {

                if (_accountService.IsExistAccount(model.Login, model.Password))
                {
                    FormsAuthentication.SetAuthCookie(model.Login, model.RememberMe);
                    if (Url.IsLocalUrl(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    return RedirectToAction("Index", "Watch");
                }
                else
                    ModelState.AddModelError("", "Пользователя с таким логином и паролем нет");

            }
            return View(model);
        }
        public ActionResult Logoff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Watch");
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                if (_accountService.IsUniqueLogin(model.Name))
                {
                    Account account = new Account()
                    {
                        Login = model.Name,
                        Password = model.Password
                    };
                    using (var db = new WatchStoreDataContext())
                    {
                        db.Accounts.Add(account);
                        db.SaveChanges();
                        return RedirectToAction("Index", "Watch");
                    }
                }
                else
                    ModelState.AddModelError("", "Пользователя с таким логином уже существует");
            }
            return View();
        }
    }
}

