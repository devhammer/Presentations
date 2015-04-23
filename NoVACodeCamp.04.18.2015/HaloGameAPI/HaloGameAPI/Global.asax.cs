using HaloGameAPI.StartMyApp;
using System;
using System.Web;
using System.Web.Http;

namespace HaloGameAPI
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            GlobalConfiguration.Configure(SetupDahAPI.DoSomeStuffToGetReady);
        }
    }
}