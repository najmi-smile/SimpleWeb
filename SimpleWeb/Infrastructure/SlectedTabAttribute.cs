using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleWeb.Infrastructure
{
    public class SlectedTabAttribute
    {
        string _slectedTab;
        public SlectedTabAttribute(string selectedTab)
        {
            this._slectedTab = selectedTab;
        }
    }
}