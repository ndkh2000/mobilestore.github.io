using ModelEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TestUngDung.Areas.KHANHHUNG.Controllers
{
    public class HomeController : Controller
    {
        // GET: KHANHHUNG/Home
        public ActionResult Index()
        {   
            if(Session[Constants.USER_SESSION] == null)
                return RedirectToAction("Index", "Login");
            return View();
        }

        public ActionResult Logout()
        {
            Session[Constants.USER_SESSION] = null;
            return RedirectToAction("Index","Login");
        }
    }
}