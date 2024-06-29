using Ecommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using System.Net;

namespace Ecommerce.Controllers
{
    public class BlogController : Controller
    {
        private BookShopEntities3 db = new BookShopEntities3();

        // GET: Admin/AdminTinTucs
        public ActionResult Index(int? page)
        {
            int pageSize = 10; // Số lượng tin tức trên mỗi trang
            ViewBag.PageSize = pageSize;

            int pageNumber = (page ?? 1);

            var posts = db.TinTucs.OrderByDescending(p => p.PostID);

            return View(posts.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TinTuc tinTuc = db.TinTucs.Find(id);
            if (tinTuc == null)
            {
                return HttpNotFound();
            }
            return View(tinTuc);
        }
    }
}