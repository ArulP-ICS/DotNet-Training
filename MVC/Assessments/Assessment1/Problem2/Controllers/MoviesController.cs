using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Problem2.Models;
using Problem2.Repository;

namespace Problem2.Controllers
{
    public class MoviesController : Controller
    {
        MovieRepository repo = new MovieRepository();

        public ActionResult Index()
        {
            return View(repo.GetAllMovies());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Movie movie)
        {
            repo.Insert(movie);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            return View(repo.GetMovie(id));
        }

        [HttpPost]
        public ActionResult Edit(Movie movie)
        {
            repo.Update(movie);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            return View(repo.GetMovie(id));
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            repo.Delete(id);
            return RedirectToAction("Index");
        }

        public ActionResult SearchByYear()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SearchByYear(int year)
        {
            return View("Index",
                repo.GetMoviesByYear(year));
        }

        public ActionResult SearchByDirector()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SearchByDirector(string directorName)
        {
            return View("Index",
                repo.GetMoviesByDirector(directorName));
        }
    }
}