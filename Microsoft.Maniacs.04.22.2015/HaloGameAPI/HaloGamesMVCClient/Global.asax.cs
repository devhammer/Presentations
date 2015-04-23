using HaloGamesMVCClient.App_Start;
using System.Web.Mvc;
using System.Web.Routing;

namespace HaloGamesMVCClient
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start()
        {
            // AreaRegistration.RegisterAllAreas();
            Register.RegisterRoutes(RouteTable.Routes);
        }
    }
}