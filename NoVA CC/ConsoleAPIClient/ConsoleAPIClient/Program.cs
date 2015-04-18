using HaloGameAPI.ModelizeMe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAPIClient
{
    class Program
    {
        static void Main(string[] args)
        {
            GetAPIData();
            Console.ReadLine();
        }

        private static async void GetAPIData()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:54407/");
                //client.BaseAddress = new Uri("http://haloaapitest.azurewebsites.net/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // This will throw an exception if the service is not available.
                HttpResponseMessage response = await client.GetAsync("myapi/HaloGames");
                if (response.IsSuccessStatusCode)
                {
                    List<HaloGame> HaloGames = await response.Content.ReadAsAsync<List<HaloGame>>();
                    foreach (HaloGame game in HaloGames)
                    {
                        Console.WriteLine("Id: {0}", game.Id);
                        Console.WriteLine("Title: {0}", game.Title);
                        Console.WriteLine("Release Date: {0}", game.ReleaseDate);
                        Console.WriteLine("--");
                    }
                }
                else
                {
                    Console.WriteLine("Error retrieving data.");
                }
            }
        }
    }
}
