using SimpleWeb.Infrastructure;
using System.Web.Mvc;

namespace SimpleWeb.Areas.Admin.Controllers
{
    [Authorize(Roles = "admin")]
    [SlectedTab("users")]
    public class UsersController : Controller
    {
        // GET: Admin/Users
        public ActionResult Index()
        {
            return View();
        }
    }
}