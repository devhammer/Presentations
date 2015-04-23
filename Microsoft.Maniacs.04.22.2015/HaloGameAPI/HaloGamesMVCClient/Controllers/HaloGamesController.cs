using HaloGameAPI.Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace HaloGamesMVCClient.Controllers
{
    public class HaloGamesController : Controller
    {

        //public static List<HaloGame> HaloGames = new List<HaloGame>
        //    {
        //        new HaloGame { Id = 1, Title = "Halo: Combat Evolved", ReleaseDate = new DateTime(2001, 11, 15) },
        //        new HaloGame { Id = 2, Title = "Halo 2", ReleaseDate = new DateTime(2004, 11, 9) },
        //        new HaloGame { Id = 3, Title = "Halo 3", ReleaseDate = new DateTime(2007, 9, 25) },
        //        new HaloGame { Id = 4, Title = "Halo Wars", ReleaseDate = new DateTime(2009, 3, 1) },
        //        new HaloGame { Id = 5, Title = "Halo 3: ODST", ReleaseDate = new DateTime(2009, 9, 22) },
        //        new HaloGame { Id = 6, Title = "Halo: Reach", ReleaseDate = new DateTime(2010, 9, 14) },
        //        new HaloGame { Id = 7, Title = "Halo 4", ReleaseDate = new DateTime(2012, 11, 6) },
        //        new HaloGame { Id = 8, Title = "Halo: Spartan Assault", ReleaseDate = new DateTime(2013, 7, 18) },
        //        new HaloGame { Id = 9, Title = "Halo: Spartan Strike", ReleaseDate = new DateTime(2015, 4, 16) },
        //        new HaloGame { Id = 10, Title = "Halo 5: Guardians", ReleaseDate = new DateTime(2015, 11, 15) }
        //    };

        // GET: HaloGames
        public async Task<ActionResult> Index()
        {
            
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:63444/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync("api/HaloGames");
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
