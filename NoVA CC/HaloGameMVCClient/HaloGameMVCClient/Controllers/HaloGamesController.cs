using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using HaloGameAPI.ModelizeMe;

namespace HaloGameMVCClient.Controllers
{
    public class HaloGamesController : Controller
    {

        // GET: HaloGames
        public async Task<ActionResult> Index()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:54407/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync("myapi/HaloGames");
                if (response.IsSuccessStatusCode)
                {
                    List<HaloGame> HaloGames = await response.Content.ReadAsAsync<List<HaloGame>>();
                    return View(HaloGames);
                }
                else
                {
                    return new HttpNotFoundResult();
                }
            }
        }
    }
}
