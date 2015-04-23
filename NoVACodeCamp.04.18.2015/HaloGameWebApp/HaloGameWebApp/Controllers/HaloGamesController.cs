using HaloGameWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HaloGameWebApp.Controllers
{
    public class HaloGamesController : Controller
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

        // GET: HaloGames
        public ActionResult Index()
        {
            return View(HaloGames);
        }

        // GET: HaloGames/Details/5
        public ActionResult Details(int id)
        {
            HaloGame game = HaloGames.Find(x => x.Id == id);
            if (game != null)
            {
                return View(game);
            }
            else
            {
                return new HttpNotFoundResult();
            }
        }

        // GET: HaloGames/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HaloGames/Create
        [HttpPost]
        public ActionResult Create(HaloGame game)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    game.Id = HaloGames.Count + 1;
                    HaloGames.Add(game);
                    return RedirectToAction("Index");
                }
                else
                {
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: HaloGames/Edit/5
        public ActionResult Edit(int id)
        {
            HaloGame game = HaloGames.Find(x => x.Id == id);
            return View(game);
        }

        // POST: HaloGames/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, HaloGame game)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    HaloGame gameToEdit = HaloGames.Find(x => x.Id == id);
                    gameToEdit.Title = game.Title;
                    gameToEdit.ReleaseDate = game.ReleaseDate;
                }
                else
                {
                    return View();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: HaloGames/Delete/5
        public ActionResult Delete(int id)
        {
            HaloGame game = HaloGames.Find(x => x.Id == id);
            return View(game);
        }

        // POST: HaloGames/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                if (HaloGames.Exists(x => x.Id == id))
                {
                    HaloGames.Remove(HaloGames.Find(x => x.Id == id));
                    return RedirectToAction("Index");
                }
                else
                {
                    return new HttpNotFoundResult();
                }
            }
            catch
            {
                return View();
            }
        }
    }
}
