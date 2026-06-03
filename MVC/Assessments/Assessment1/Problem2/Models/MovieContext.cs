using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Problem2.Models
{
    public class MovieContext : DbContext
    {
        public MovieContext() : base("MovieContext")
        {
        }

        public DbSet<Movie> Movies { get; set; }
    }
}