using SimpleWeb.Areas.Admin.ViewModels;
using SimpleWeb.Infrastructure;
using SimpleWeb.Models;
using NHibernate.Linq;
using System.Web.Mvc;
using System.Linq;

namespace SimpleWeb.Areas.Admin.Controllers
{
    [Authorize(Roles = "admin")]
    [SlectedTab("users")]
    public class UsersController : Controller
    {
        // GET: Admin/Users
        public ActionResult Index()
        {
            return View(new UserIndex
            {
                Users = Database.Session.Query<UserModel>().ToList()
            });
        }

        [HttpGet]
        public ActionResult New()
        {
            return View(new UsersNew()
            {

            });
        }
        [HttpPost]
        public ActionResult New(UsersNew form)
        {
            if (Database.Session.Query<UserModel>().Any(u => u.UserName == form.UserName))
                ModelState.AddModelError("UserName", "Username must be unique!");
            if (!ModelState.IsValid)
                return View(form);
            var user = new UserModel
            {
                Email = form.Email,
                UserName = form.UserName
            };
            user.SetPassword(form.Password);
            Database.Session.Save(user);
            return RedirectToAction("index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var user = Database.Session.Load<UserModel>(id);
            if (user == null)
                return HttpNotFound();
            return View(new UsersEdit
            {
                UserName = user.UserName,
                Email = user.Email
            });
        }
        [HttpPost]
        public ActionResult Edit(int id, UsersEdit form)
        {
            var user = Database.Session.Load<UserModel>(id);
            if (user == null)
                return HttpNotFound();
            if (Database.Session.Query<UserModel>().Any(u => u.UserName == form.UserName && u.Id != id))
                ModelState.AddModelError("Username", "Username must be unique!");
            if (!ModelState.IsValid)
                return View(form);
        }
    }
}