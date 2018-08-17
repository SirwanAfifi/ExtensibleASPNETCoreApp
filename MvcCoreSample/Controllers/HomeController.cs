using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MvcCoreSample.DataLayer;

namespace MvcCoreSample.Controllers
{
    public class HomeController : Controller
    {
        private readonly MovieDbContext _movieDbContext;
        public HomeController(MovieDbContext movieDbContext)
        {
            _movieDbContext = movieDbContext;
        }

        public IActionResult Index()
        {
            var movies = _movieDbContext.Movies.ToList();
            return Json(movies);
        }
    }
}