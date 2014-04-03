using INT422TestTwo.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace INT422TestTwo.Controllers
{
  [Authorize]
    public class MovieController : Controller
    {
        RepoMovie Repo_Movie = new RepoMovie();

        //
        // GET: /Movie/
        public ActionResult Index()
        {
            return View(Repo_Movie.GetMoviesForList());
        }

        //
        // GET: /Movie/Details/5
        public ActionResult Details(int id)
        {
            return View(Repo_Movie.GetMovieForDetails(id));
        }

        //
        // GET: /Movie/Create
      [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            ViewBag.GenresList = Repo_Movie.getSelectGenresList();
            ViewBag.DirectorList = Repo_Movie.getSelectDirectorsList();
            return View();
        }

        //
        // POST: /Movie/Create
        [HttpPost]
        public ActionResult Create(MovieFull mf, FormCollection collection)
        {
            ViewBag.GenresList = Repo_Movie.getSelectGenresList();
            ViewBag.DirectorList = Repo_Movie.getSelectDirectorsList();

            try
            {
               if (ModelState.IsValid)
                {
                    if (collection.Count == 5)
                    {
                          Repo_Movie.CreateMovie(mf, collection[3], collection[4]);
                    }
                    else if (collection.Count == 4)
                    {
                            // if only Genre selected
                            Repo_Movie.CreateMovie(mf, "", collection[3]);
                    }
                    else
                    {
                         Repo_Movie.CreateMovie(mf);
                    }
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Movie/Edit/5
      [Authorize(Roles = "Admin")]
        public ActionResult Edit(int id)
        {
            return View(Repo_Movie.GetMovieFull(id));
        }

        //
        // POST: /Movie/Edit/5
        [HttpPost]
        public ActionResult Edit(MovieFull mf, FormCollection collection)
        {
            try
            {
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Movie/Delete/5
      [Authorize(Roles = "Admin")]
        public ActionResult Delete(int id)
        {
            var movie = Repo_Movie.getMovieFullAM(id);
            return View(movie);
        }

        //
        // POST: /Movie/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {

                Repo_Movie.deleteMovie(id);

                return RedirectToAction("Index");

        }
    }
}
