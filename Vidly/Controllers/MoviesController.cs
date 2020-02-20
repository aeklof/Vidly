using System.Collections.Generic;
using System.Data.Entity.Infrastructure.MappingViews;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.WebSockets;
using Antlr.Runtime.Misc;
using Vidly.Models;
using Vidly.ViewModel;
using static System.String;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies/Random
        public ActionResult Random()
        {
            var movie = new Movie() {Name = "Shrek!"};
            var customers = new List<Customer>
            {
                new Customer {Name = "Customer 1"},
                new Customer {Name = "Customer 2"}
            };

            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };
            return View(viewModel);
            //return HttpNotFound();
            //return new EmptyResult();

           // return RedirectToAction("Index", "Home", new {page = 1, sortBy = "name"});

        }

        public ActionResult Edit(int id)
        {
            return Content("id=" + id);
        }

        public ActionResult Index(int? pageIndex, string sortBy)
        {
            if (!pageIndex.HasValue)
                pageIndex = 1;

            if (IsNullOrWhiteSpace(sortBy))
                sortBy = "Name";

            return Content($"pageIndex={pageIndex}&sortBy={sortBy}");
        }

        [Route("movies/released/{year}/{month:regex(\\d{2})}:range(1,12)")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }

        [Route("movies")]
        public ActionResult AllMovies()
        {
            var movies = new List<Movie>
            {
                new Movie {Name = "Shrek!"},
                new Movie {Name = "Wall-e"}
            };

            var viewModel = new AllMoviesViewModel
            {
                Movies = movies
            };

            return View(viewModel);

        }




    }
}