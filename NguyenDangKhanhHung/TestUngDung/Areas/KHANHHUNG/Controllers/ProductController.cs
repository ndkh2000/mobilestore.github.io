using ModelEF.DAO;
using ModelEF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestUngDung.Areas.KHANHHUNG.Models;

namespace TestUngDung.Areas.KHANHHUNG.Controllers
{
    public class ProductController : Controller
    {
        // GET: KHANHHUNG/Product
        public ActionResult Index(string searchstring, int page = 1, int pagesize = 5)
        {
            var user = new ProductDao();
            var model = user.ListAllPaging(searchstring, page, pagesize);
            ViewBag.SearchString = searchstring;
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            SetViewBag();
            return View();
        }
        //Thêm mới
        [HttpPost]
        public ActionResult Create(Product model)
        {
            if (ModelState.IsValid)
            {
                var dao = new ProductDao();
                var result = dao.Insert(model);
                if (!string.IsNullOrEmpty(result))
                {
                    return RedirectToAction("Index", "Product");
                }
                else
                {
                    ModelState.AddModelError("", "Create success");
                }
            }
            return View();
        }
        //Dropdownlist category
        public void SetViewBag(long? selectedID=null)
        {
            var dao = new CategoryDao();
            ViewBag.Name = new SelectList(dao.ListAll(), "ID", "Name", selectedID);
        }

        [ChildActionOnly]
        public PartialViewResult Category(Category model)
        {
            var dao = new CategoryDao().ListAll();
            return PartialView(model);
        }

        public ActionResult Detail(long id)
        {
            var result = new ProductDao().Find(id);
            return View(result);
        }

    }
}
