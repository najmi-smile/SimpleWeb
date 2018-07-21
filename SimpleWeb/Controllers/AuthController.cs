using SimpleWeb.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace SimpleWeb.Controllers
{
    public class AuthController : Controller
    {
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToRoute("home");
        }
        // GET: Auth
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(AuthLogin form, string returnUrl)
        {
            if(!ModelState.IsValid)
            {
                return View(form);
            }
            //  TODO Change this with database authentication
            FormsAuthentication.SetAuthCookie(form.Username,true);
            if(!string.IsNullOrWhiteSpace(returnUrl))
            {
                // TODO: Make sure dont redirect to another domain for security purposes
                return Redirect(returnUrl);
            }
            return Redirect("/");
        }
       
    }
}