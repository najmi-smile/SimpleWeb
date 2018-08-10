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
            user.UserName = form.UserName;
            user.Email = form.Email;
            Database.Session.Update(user);
            return RedirectToAction("index");
        }

        public ActionResult ResetPassword(int id)
        {
            var user = Database.Session.Load<UserModel>(id);
            if (user == null)
                return HttpNotFound();
            return View(new UsersResetPassword
            {
                UserName = user.UserName
            });
        }

        [HttpPost]
        public ActionResult ResetPassword(int id, UsersResetPassword form)
        {
            var user = Database.Session.Load<UserModel>(id);
            if (user == null)
                return HttpNotFound();

            if (Database.Session.Query<UserModel>().Any(u => u.UserName == form.UserName && u.Id != id))
                ModelState.AddModelError("Username", "Username must be unique!");

            form.UserName = user.UserName;

            if (!ModelState.IsValid)
                return View(form);

            user.SetPassword(form.Password);
            
            Database.Session.Update(user);
            return RedirectToAction("index");
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            // uses script Form.js in Scripts folder to confirm and delete the entry
            var user = Database.Session.Load<UserModel>(id);
            if (user == null)
                return HttpNotFound();
            Database.Session.Delete(user);
            return RedirectToAction("index");
        }
    }
}