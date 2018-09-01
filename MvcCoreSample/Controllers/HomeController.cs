using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MvcCoreSample.DataLayer;
using MvcCoreSample.DomainClasses.Contracts;
using MvcCoreSample.Extensibility.Common;
using MvcCoreSample.Services.Contracts;

namespace MvcCoreSample.Controllers
{
    public class HomeController : Controller
    {
        private readonly MovieDbContext _movieDbContext;
        private readonly ICommerceEngine _commerceEngine;
        private readonly AppSettings _appSettings;

        public HomeController(MovieDbContext movieDbContext, ICommerceEngine commerceEngine,
            IOptions<AppSettings> appSettings)
        {
            _movieDbContext = movieDbContext;
            _commerceEngine = commerceEngine;
            _appSettings = appSettings.Value;
        }

        public IActionResult Index()
        {
            _commerceEngine.ProcessOrder(new DomainClasses.OrderData { });
            var movies = _movieDbContext.Movies.ToList();
            return Json(movies);
        }
    }
}