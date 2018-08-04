using NHibernate;
using NHibernate.Cfg;
using NHibernate.Mapping.ByCode;
using SimpleWeb.Models;
using System.Web;

namespace SimpleWeb
{
    //  Step 1
    //  Application configurations
    public static class Database
    {
        private const string SessionKey = "SimpleWeb.Database.SessionKey";
        private static ISessionFactory sessionFactory;

        public static ISession Session
        {
            get { return (ISession)HttpContext.Current.Items[SessionKey]; }
        }
        public static void Configure()
        {
            var config = new Configuration();
            
            // configure the connection string
            config.Configure();
            
            // add our mapping
            var mapper = new ModelMapper();
            mapper.AddMapping<UserMap>();
            config.AddMapping(mapper.CompileMappingForAllExplicitlyAddedEntities());

            // create session factory
            //  As the session factory is going to be used
            //  from both methods below so it will be stored in variable
            sessionFactory = config.BuildSessionFactory();
        }
        public static void OpenSession()
        {
            HttpContext.Current.Items[SessionKey] = sessionFactory.OpenSession();
        }
        public static void CloseSession()
        {
            var session = HttpContext.Current.Items[SessionKey] as ISession;
            if(session != null)
            {
                sessionFactory.Close();
            }
            HttpContext.Current.Items.Remove(SessionKey);
        }
    }
}