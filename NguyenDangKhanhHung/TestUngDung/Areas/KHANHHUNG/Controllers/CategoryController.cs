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
    public class CategoryController : Controller
    {
        // GET: KHANHHUNG/Category
        public ActionResult Index(string searchstring, int page = 1, int pagesize = 5)
        {
            var user = new CategoryDao();
            var model = user.ListAllPaging(searchstring, page, pagesize);
            ViewBag.SearchString = searchstring;
            return View(model);
        }
    }

}