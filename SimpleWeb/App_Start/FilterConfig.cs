using SimpleWeb.Infrastructure;
using System.Web.Mvc;

namespace SimpleWeb
{
    public class FilterConfig
    {
       public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new TransactionFilter());
            filters.Add(new HandleErrorAttribute());
        }

    }
}