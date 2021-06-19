using ModelEF.DAO;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TestUngDung.Areas.KHANHHUNG.Controllers
{
    public class UserController : BaseController
    {
        // GET: KHANHHUNG/User
        //Hiển thị danh sách người dùng

       public ActionResult Index(string searchstring, int page = 1, int pagesize = 5)
        {
            var user = new UserDao();
            var model = user.ListAllPaging(searchstring, page, pagesize);
            ViewBag.SearchString = searchstring;
            return View(model);
        }
        


        public ActionResult Delete (int id)
        {
            new UserDao().Delete(id);
            return RedirectToAction("Index");
        }
    }

}