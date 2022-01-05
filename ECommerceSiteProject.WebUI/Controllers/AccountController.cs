using ECommerceSiteProject.WebUI.Entity;
using ECommerceSiteProject.WebUI.Identity;
using ECommerceSiteProject.WebUI.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ECommerceSiteProject.WebUI.Controllers
{
    public class AccountController : Controller
    {
        private DataContext db = new DataContext();
        private UserManager<ApplicationUser> userManager;
        private RoleManager<ApplicationRole> roleManager;
        public AccountController()
        {
            var userStore = new UserStore<ApplicationUser>(new IdentityDataContext());
            userManager = new UserManager<ApplicationUser>(userStore);

            var roleStore = new RoleStore<ApplicationRole>(new IdentityDataContext());
            roleManager = new RoleManager<ApplicationRole>(roleStore);
        }
        [Authorize]
        public ActionResult Index()
        {
            var userName = User.Identity.Name;
            var orders = db.Orders
                .Where(x => x.UserName == userName)
                .Select(x => new UserOrderModel()
                {
                    Id = x.Id,
                    OrderNumber = x.OrderNumber,
                    OrderDate = x.OrderDate,
                    OrderState = x.OrderState,
                    Total = x.Total
                }).OrderByDescending(x=>x.OrderDate).ToList();
            return View(orders);
        }
        [Authorize]
        public ActionResult Details(int id)
        {
            var entity = db.Orders
                .Where(x => x.Id == id)
                .Select(x => new OrderDetailsModel()
                {
                    OrderId = x.Id,
                    OrderNumber = x.OrderNumber,
                    Total = x.Total,
                    OrderDate = x.OrderDate,
                    OrderState = x.OrderState,
                    AdresBasligi = x.AdresBasligi,
                    Adres = x.Adres,
                    Sehir = x.Sehir,
                    Semt = x.Semt,
                    Mahalle = x.Mahalle,
                    PostaKodu = x.PostaKodu,
                    OrderLines = x.OrderLines.Select(i => new OrderLineModel()
                    {
                        ProductId = i.ProductId,
                        ProductName = i.Product.Name,
                        Image = i.Product.Image,
                        Quantity = i.Quantity,
                        Price = i.Price
                    }).ToList()
                }).FirstOrDefault();
            return View(entity);
        }
        // GET: Account
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(Register model)
        {
            if (ModelState.IsValid)
            {
                //kayıt işlemleri
                ApplicationUser user = new ApplicationUser();
                user.Name = model.Name;
                user.SurName = model.SurName;
                user.Email = model.Email;
                user.UserName = model.UserName;

                var result = userManager.Create(user, model.Password);
                if (result.Succeeded)
                {
                    //kullanıcı rolü oluştu
                    if (roleManager.RoleExists("User"))
                    {
                        userManager.AddToRole(user.Id, "User");
                    }
                    return RedirectToAction("Login", "Account");
                }
                else
                {
                    ModelState.AddModelError("RegisterUserError", "Kullanıcı oluşturulamadı");
                }
            }
            return View(model);
        }

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Login model, string ReturnUrl)
        {
            if (ModelState.IsValid)
            {
                //Login işlemleri
                var user = userManager.Find(model.UserName, model.Password);
                if (user != null)
                {
                    //Var olan kullanıcıyı sisteme dahil et
                    var authManager = HttpContext.GetOwinContext().Authentication;
                    var identityClaims = userManager.CreateIdentity(user, "ApplicationCookie");
                    var authProperties = new AuthenticationProperties();
                    authProperties.IsPersistent = model.RememberMe;
                    authManager.SignIn(authProperties, identityClaims);

                    if (String.IsNullOrEmpty(ReturnUrl))
                    {
                        Redirect(ReturnUrl);
                    }

                    return RedirectToAction("Index", "Home");
                }
                else
                
                {
                    ModelState.AddModelError("LoginUserError", "Kullanıcı Girişi Yapılamadı");
                }
            }
            return View(model);
        }

        public ActionResult Logout()
        {
            var authManager = HttpContext.GetOwinContext().Authentication;
            authManager.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}