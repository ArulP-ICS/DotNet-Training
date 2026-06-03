using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Problem2.Models;

namespace Problem2.Repository
{
    public class MovieRepository : IMovieRepository
    {
        MovieContext db = new MovieContext();

        public List<Movie> GetAllMovies()
        {
            return db.Movies.ToList();
        }

        public Movie GetMovie(int id)
        {
            return db.Movies.Find(id);
        }

        public void Insert(Movie movie)
        {
            db.Movies.Add(movie);
            db.SaveChanges();
        }

        public void Update(Movie movie)
        {
            db.Entry(movie).State =
            System.Data.Entity.EntityState.Modified;

            db.SaveChanges();
        }

        public void Delete(int id)
        {
            Movie m = db.Movies.Find(id);

            if (m != null)
            {
                db.Movies.Remove(m);
                db.SaveChanges();
            }
        }

        public List<Movie> GetMoviesByYear(int year)
        {
            return db.Movies
                     .Where(x => x.DateOfRelease.Year == year)
                     .ToList();
        }

        public List<Movie> GetMoviesByDirector(string director)
        {
            return db.Movies
                     .Where(x => x.DirectorName == director)
                     .ToList();
        }
    }
}