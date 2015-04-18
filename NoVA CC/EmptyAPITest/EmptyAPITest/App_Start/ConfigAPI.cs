using System.Web.Http;

namespace EmptyAPITest.App_Start
{
    public static class ConfigAPI
    {
        public static void RegisterMyAPI(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "MyCoolRoute",
                routeTemplate: "myapi/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
                );
        }
    }
}