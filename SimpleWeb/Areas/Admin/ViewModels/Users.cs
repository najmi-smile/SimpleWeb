using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using SimpleWeb.Models;


namespace SimpleWeb.Areas.Admin.ViewModels
{
    public class UserIndex
    {
        public IEnumerable<UserModel> Users { get; set; }
    }
    public class UsersNew
    {
        [Required, MaxLength(128)]
        public string UserName { get; set; }
        [Required,DataType(DataType.Password)]
        public string Password { get; set; }
        [Required, DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }

    public class UsersEdit
    {
        [Required, MaxLength(128)]
        public string UserName { get; set; }
        [Required, DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}