using Microsoft.AspNetCore.Mvc;
using MvcCoreSample.DataLayer;
using MvcCoreSample.DomainClasses;

namespace MvcCoreSample.Controllers
{
    public class HomeController : Controller
    {
        private readonly GenericRepository<Movie> _movieRepository;

        public HomeController(GenericRepository<Movie> movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public IActionResult Index()
        {
            var movies = _movieRepository.All();
            return Json(movies);
        }
    }
}