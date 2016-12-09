using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies
        //public ActionResult Index()
        //{
        //    //var movie = new Movie() { Id = 10, Name = "Test List" };

        //    var movies = GetMovies();
            
        //    return View(movies);
        //}

        private IEnumerable<Movie> GetMovies()
        {
            return new List<Movie>
            {
                new Movie { Id = 1, Name = "Shrek" },
                new Movie { Id = 2, Name = "WALL-e" }
            };
        }

        
        public ActionResult Random()
        {
            var movie = new Movie() { Id = 10, Name = "Shrek" };
            var customers = new List<Customer> {
                new Customer { Name="Customer 1"},
                new Customer { Name="Customer 2"}
            };

            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };
            
            return View(viewModel);
            //return Content("Hello World");
            //return HttpNotFound();
            //return new EmptyResult();
            //return RedirectToAction("Index", "Home", new { page = 1, sortBy = "Name" });

        }

        //public ActionResult Edit(int id)
        //{
        //    return Content("id=" + id);
        //}

        public ActionResult Index(int? pageIndex, string sortBy)
        {
            if (!pageIndex.HasValue)
                pageIndex = 1;

            if (string.IsNullOrWhiteSpace(sortBy))
                sortBy = "Name";
            return Content("pageIndex=" + pageIndex.ToString() + "sortBy=" + sortBy);
        }

        [Route("movies/released/{year}/{month:regex(\\d{4}):range(1,12)}")]
        public ActionResult ByReleaseYear(int year,int month)
        {
            return Content(year+"/"+month);
        }
        

    }
}