using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace SimpleWeb.Models
{
    public class UserModel
    {
        //  every single class which needs to map 
        //  through hibernate must have every member be virtual
        public virtual int Id { get; set; }
        public virtual string UserName { get; set; }
        public virtual string Email { get; set; }
        public virtual string Password { get; set; }
        public virtual void SetPassword(string password)
        {
            Password = password;
        }
    }
    public class UserMap : ClassMapping<UserModel>
    {
        public UserMap()
        {
            //   need to tell hibernate which table in the database we maping
            Table("Users");
            //  for auto generated Id by Database
            Id(x => x.Id, x => x.Generator(Generators.Identity));
            Property(x => x.UserName, x => x.NotNullable(true));
            Property(x => x.Email, x => x.NotNullable(true));
            Property(x => x.Password, x => x.NotNullable(true));
        }

    }
}