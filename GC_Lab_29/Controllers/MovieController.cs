using GC_Lab_29.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GC_Lab_29.Controllers
{
    public class MovieController : ApiController
    {
        [HttpGet]
       public List<movie> GetAllMovies()
        {
            moviesEntities ORM = new moviesEntities();
            List<movie> allmovies = ORM.movies.ToList();
            return allmovies;
        }
        public movie GetAMovie()
        {
            moviesEntities ORM = new moviesEntities();
            List<movie> pickMovie = ORM.movies.ToList();
            Random r = new Random();
            int selected = r.Next(0, pickMovie.Count-1);
            return pickMovie.ElementAt(selected);
        }
        public movie GetAMovieInCat(string category)
        {
            moviesEntities ORM = new moviesEntities();
            List<movie> pickMovie = ORM.movies.Where(x => x.category.ToLower() == category.ToLower()).ToList(); 
            Random r = new Random();
            int selected = r.Next(0, pickMovie.Count - 1);
            return pickMovie.ElementAt(selected);
        }
        public List<movie> GetSomeMovies(int num)
        {
            moviesEntities ORM = new moviesEntities();
            List<movie> pickMovie = ORM.movies.ToList();
            Random r = new Random();
            List<movie> randommovies = new List<movie>();
            for (int i = 0; i < num; i++)
            {
                int selected = r.Next(0, pickMovie.Count - 1);
                randommovies.Add(pickMovie.ElementAt(selected));
            }
            return randommovies;
        }
        public List<string> GetAllCategories()
        {
            moviesEntities ORM = new moviesEntities();
            
            return ORM.movies.Where(x => x.category != null).Select(x => x.category).Distinct().ToList(); ;
        }
        public List<string> GetSpecific(string movie)
        {
            moviesEntities ORM = new moviesEntities();

            return ORM.movies.Where(x => x.title == movie.ToLower() != false).Select(x => x.title + "is an a" + x.category + "film").Distinct().ToList(); 
        }
        public List<string> GetKey(string movie)
        {
            moviesEntities ORM = new moviesEntities();

            return ORM.movies.Where(x => x.title.Contains(movie.ToLower()) != false).Select(x => x.title + "is an a " + x.category + " film").Distinct().ToList();
        }
    }
}
