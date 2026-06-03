using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Problem2.Models;

namespace Problem2.Repository
{
    public interface IMovieRepository
    {
        List<Movie> GetAllMovies();

        Movie GetMovie(int id);

        void Insert(Movie movie);

        void Update(Movie movie);

        void Delete(int id);

        List<Movie> GetMoviesByYear(int year);

        List<Movie> GetMoviesByDirector(string director);
    }
}