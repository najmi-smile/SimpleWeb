using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace SimpleWeb
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundle)
        {
            //  CSS bundles
            // its a virtual path for admin side of the project
            bundle.Add(new StyleBundle("~/admin/styles")   
                .Include("~/Content/Styles/bootstrap.css")
                .Include("~/Content/Styles/admin.css"));
            // this virtual path is for genral web site use
            bundle.Add(new StyleBundle("~/styles")      
                .Include("~/Content/Styles/bootstrap.css")
                .Include("~/Content/Styles/site.css"));

            //  Scripts Bundles
            // its a virtual path for admin side of the project
            bundle.Add(new ScriptBundle("~/admin/scripts")
                .Include("~/scripts/jquery-3.3.1.js")
                .Include("~/jquery.validate.js")
                .Include("~/bootstrap.js")
                .Include("~/areas/admin/scripts/forms.js"));
            // this virtual path is for genral web site use
            bundle.Add(new ScriptBundle("~/scripts")
                .Include("~/scripts/jquery-3.3.1.js")
                .Include("~/jquery.validate.js")
                .Include("~/jquery-3.3.1.slim.js")
                .Include("~/bootstrap.js"));
        }
    }
}