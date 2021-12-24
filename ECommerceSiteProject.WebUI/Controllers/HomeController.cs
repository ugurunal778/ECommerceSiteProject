﻿using ECommerceSiteProject.WebUI.Entity;
using ECommerceSiteProject.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ECommerceSiteProject.WebUI.Controllers
{
    public class HomeController : Controller
    {
        DataContext _context = new DataContext();

        // GET: Home
        public ActionResult Index()
        {
            var urunler = _context.Products
                .Where(i => i.IsHome && i.IsApproved)
                .Select(i => new ProductModel()
                {
                    Id = i.Id,
                    Name = i.Name,
                    Description = i.Description.Length > 50 ? i.Description.Substring(0, 47) + "..." : i.Description,
                    Price = i.Price,
                    Stock = i.Stock,
                    Image = i.Image ?? "cart.png",
                    CategoryId = i.CategoryId
                }).ToList();
            return View(urunler);
        }
        public ActionResult Details(int id)
        {
            return View(_context.Products.Where(i => i.Id==id).FirstOrDefault());
        }
        public ActionResult List()
        {
            var urunler = _context.Products
                .Where(i => i.IsApproved)
                .Select(i => new ProductModel()
                {
                    Id = i.Id,
                    Name = i.Name.Length > 50 ? i.Name.Substring(0, 47) + "..." : i.Name,
                    Description = i.Description.Length > 50 ? i.Description.Substring(0, 47) + "..." : i.Description,
                    Price = i.Price,
                    Stock = i.Stock,
                    Image = i.Image ?? "cart.png",
                    CategoryId = i.CategoryId
                }).ToList();
            return View(urunler);
        }
    }
}