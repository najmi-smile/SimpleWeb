using System;
using System.Web.Mvc;
namespace SimpleWeb.Infrastructure
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class SlectedTabAttribute : ActionFilterAttribute
    {
        readonly string _slectedTab;
        public SlectedTabAttribute(string selectedTab)
        {
            this._slectedTab = selectedTab;
        }
        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            filterContext.Controller.ViewBag.SelectedTab = _slectedTab;
        }
    }
}