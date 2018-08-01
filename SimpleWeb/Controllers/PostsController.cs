using System.Configuration;
using SimpleWeb.Services;
using System.Web.Mvc;
using SimpleWeb.Interfaces;

namespace SimpleWeb.Controllers
{
    public class PostsController : Controller
    {
        readonly string connectionString = ConfigurationManager.ConnectionStrings[1].ConnectionString;
        
        public ActionResult Index()
        {
            UserService userService = new UserService(connectionString);
            
            var userList = userService.GetAllUsers();
            return View();
        }
    }
}