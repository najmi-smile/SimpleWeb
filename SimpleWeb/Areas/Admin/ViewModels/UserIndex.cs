using System.Collections.Generic;
using SimpleWeb.Models;


namespace SimpleWeb.Areas.Admin.ViewModels
{
    public class UserIndex
    {
        public IEnumerable<UserModel> Users { get; set; }
    }
}