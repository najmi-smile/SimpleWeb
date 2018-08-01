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
    }
}