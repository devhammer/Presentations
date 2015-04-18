using System.Web.Http;

namespace HaloGameAPI.StartMyApp
{
    public static class SetupDahAPI
    {
        public static void DoSomeStuffToGetReady(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "MyAwesomeApi",
                routeTemplate: "myapi/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}