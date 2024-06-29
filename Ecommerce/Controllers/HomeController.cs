using Ecommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CaptchaMvc;
using CaptchaMvc.HtmlHelpers;

namespace Ecommerce.Controllers
{
    public class HomeController : Controller
    {
        BookShopEntities3  db = new BookShopEntities3();

        // GET: Home
        public ActionResult Index()
        {
            // Lấy danh sách sản phẩm có rating = 5
            var products = db.Products.Where(p => p.Ratting == 5).Take(5).ToList();

            // Truyền danh sách sản phẩm đến View
            ViewData["SanPham5Sao"] = products;

            // Lấy 2 sản phẩm có rating cao nhất từ danh mục "Sách Mới Nhất"
            var topCatToy = db.Products
                .Where(p => p.Category.CatName == "Sách Mới Nhất")
                .GroupBy(p => p.Category.CatName)
                .SelectMany(group => group.OrderByDescending(p => p.Ratting).Take(4))
                .ToList();

            // Truyền danh sách sản phẩm đến View
            ViewData["topCatToy"] = topCatToy;

            // Lấy 2 sản phẩm có rating cao nhất từ danh mục "Sách Trẻ Em"
            var topCatChibi = db.Products
                .Where(p => p.Category.CatName == "Sách Trẻ Em")
                .GroupBy(p => p.Category.CatName)
                .SelectMany(group => group.OrderByDescending(p => p.Ratting).Take(4))
                .ToList();

            // Truyền danh sách sản phẩm đến View
            ViewData["topCatChibi"] = topCatChibi;

            // Lấy 2 sản phẩm có rating cao nhất từ danh mục "Sách Tri Thức"
            var topCatBottle = db.Products
                .Where(p => p.Category.CatName == "Sách Tri Thức")
                .GroupBy(p => p.Category.CatName)
                .SelectMany(group => group.OrderByDescending(p => p.Ratting).Take(4))
                .ToList();

            // Truyền danh sách sản phẩm đến View
            ViewData["topCatBottle"] = topCatBottle;

            // Lấy 2 sản phẩm có rating cao nhất từ danh mục "Sách IT"
            var topCatWatch = db.Products
                .Where(p => p.Category.CatName == "Sách IT")
                .GroupBy(p => p.Category.CatName)
                .SelectMany(group => group.OrderByDescending(p => p.Ratting).Take(4))
                .ToList();

            // Truyền danh sách sản phẩm đến View
            ViewData["topCatWatch"] = topCatWatch;

            ViewData["DanhMuc"] = new SelectList(db.Categories, "CatID", "CatName");

            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }
    }
}