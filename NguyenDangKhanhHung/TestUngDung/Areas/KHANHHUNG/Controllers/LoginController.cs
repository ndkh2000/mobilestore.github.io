using ModelEF;
using ModelEF.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestUngDung.Areas.KHANHHUNG.Models;

namespace TestUngDung.Areas.KHANHHUNG.Controllers
{
    public class LoginController : Controller
    {
        // GET: KHANHHUNG/Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(LoginModel login)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDao();
                var result = dao.login(login.username, login.password);
                if(result == 1)
                {
                    var user = dao.GetByID(login.username);
                    var usersession = new LoginModel();
                    usersession.username = user.Username;
                    usersession.password = user.Password;
                    //ModelState.AddModelError("", "Login successful");
                    Session.Add(Constants.USER_SESSION, login);
                    return RedirectToAction("Index", "Home");
                }
                else if(result == 0)
                {
                    ModelState.AddModelError("", "Account do not exist");
                }
                else if(result == -1 )
                {
                    ModelState.AddModelError("", "Account is blocked");
                }
                else if(result == -2)
                {
                    ModelState.AddModelError("", "Password is incorrect");
                }
                else
                { 
                    ModelState.AddModelError("", "Login failed");
                }
            }
            return View("Index");
        }
    }
}