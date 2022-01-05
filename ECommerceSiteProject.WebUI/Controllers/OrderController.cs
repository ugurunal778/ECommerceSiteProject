using ECommerceSiteProject.WebUI.Entity;
using ECommerceSiteProject.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ECommerceSiteProject.WebUI.Controllers
{
    [Authorize(Roles = "admin")]
    public class OrderController : Controller
    {
        DataContext db = new DataContext();
        public ActionResult Index()
        {
            var orders = db.Orders.Select(x => new AdminmOrderModel()
            {
                Id = x.Id,
                OrderNumber = x.OrderNumber,
                OrderDate = x.OrderDate,
                OrderState = x.OrderState,
                Total = x.Total,
                Count = x.OrderLines.Count
            }).OrderByDescending(x=>x.OrderDate).ToList();
            return View(orders);
        }
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
        public ActionResult UpdateOrderState(int orderId, EnumOrderState OrderState)
        {
            var order = db.Orders.FirstOrDefault(x => x.Id == orderId);
            if (order!=null)
            {
                order.OrderState = OrderState;
                db.SaveChanges();
                TempData["message"] = "Değişiklikler kaydedildi";
                return RedirectToAction("Details", new { id = orderId });
            }
            return RedirectToAction("Index");
        }
    }
}