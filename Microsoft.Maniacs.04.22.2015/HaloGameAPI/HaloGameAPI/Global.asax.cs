using System;
using System.Web.Http;

namespace HaloGameAPI
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            GlobalConfiguration.Configure(App_Start.WebApiConfig.Register);
        }

    }
}