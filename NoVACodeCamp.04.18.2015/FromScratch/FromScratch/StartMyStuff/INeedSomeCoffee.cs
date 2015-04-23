
using System.Web.Http;

namespace FromScratch.StartMyStuff
{
    public static class INeedSomeCoffee
    {
        public static void SetMeUp(HttpConfiguration config)
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