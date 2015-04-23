using HaloGameAPI.ModelizeMe;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace HaloGameAPI.ControlMe
{
    public class HaloGamesController : ApiController
    {
        public static List<HaloGame> HaloGames = new List<HaloGame>
            {
                new HaloGame { Id = 1, Title = "Halo: Combat Evolved", ReleaseDate = new DateTime(2001, 11, 15) },
                new HaloGame { Id = 2, Title = "Halo 2", ReleaseDate = new DateTime(2004, 11, 9) },
                new HaloGame { Id = 3, Title = "Halo 3", ReleaseDate = new DateTime(2007, 9, 25) },
                new HaloGame { Id = 4, Title = "Halo Wars", ReleaseDate = new DateTime(2009, 3, 1) },
                new HaloGame { Id = 5, Title = "Halo 3: ODST", ReleaseDate = new DateTime(2009, 9, 22) },
                new HaloGame { Id = 6, Title = "Halo: Reach", ReleaseDate = new DateTime(2010, 9, 14) },
                new HaloGame { Id = 7, Title = "Halo 4", ReleaseDate = new DateTime(2012, 11, 6) },
                new HaloGame { Id = 8, Title = "Halo: Spartan Assault", ReleaseDate = new DateTime(2013, 7, 18) },
                new HaloGame { Id = 9, Title = "Halo: Spartan Strike", ReleaseDate = new DateTime(2015, 4, 16) },
                new HaloGame { Id = 10, Title = "Halo 5: Guardians", ReleaseDate = new DateTime(2015, 11, 15) }
            };

        public IHttpActionResult GetAllHaloGames()
        {
            return Ok(HaloGames);
        }

        public IHttpActionResult GetGameById(int Id)
        {

            if (HaloGames.Exists(x => x.Id == Id))
            {
                HaloGame game = HaloGames.Find(x => x.Id == Id);
                if (Id == 5)
                {
                    HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
                    response.Content = new ObjectContent<HaloGame>(game, new JsonMediaTypeFormatter());
                    response.Headers.CacheControl = new CacheControlHeaderValue() 
                    { 
                        MaxAge = TimeSpan.FromMinutes(2)
                    };
                    return ResponseMessage(response);
                }
                else
                {
                    return Ok(game);
                }
            }
            else
            {
                return NotFound();
            }
        }

        public IHttpActionResult PostNewGame([FromBody]HaloGame game)
        {
            try
            {
                HaloGames.Add(game);
            }
            catch (Exception e)
            {
                return StatusCode(HttpStatusCode.InternalServerError);
            }
            return CreatedAtRoute("MyAwesomeApi", new { id = game.Id }, game);
        }

        public IHttpActionResult PutGameUpdate(int Id, [FromBody] HaloGame game)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (Id != game.Id)
            {
                return BadRequest();
            }

            if (HaloGames.Exists(x => x.Id == game.Id))
            {
                HaloGame gameToUpdate = HaloGames.Find(x => x.Id == game.Id);
                gameToUpdate.Title = game.Title;
                gameToUpdate.ReleaseDate = game.ReleaseDate;
                return StatusCode(HttpStatusCode.NoContent);
            }
            else
            {
                return NotFound();
            }
        }

        public IHttpActionResult DeleteGame(int Id)
        {
            if (HaloGames.Exists(x => x.Id == Id))
            {
                HaloGame game = HaloGames.Find(x => x.Id == Id);
                HaloGames.Remove(game);
                return Ok(game);
            }
            else
            {
                return NotFound();
            }
        }
    }
}