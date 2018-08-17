using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MvcCoreSample.DataLayer;
using MvcCoreSample.DomainClasses;
using MvcCoreSample.Extensibility.Common;

namespace MvcCoreSample.Pages
{
    public class CreateModel : PageModel
    {
        private readonly MovieDbContext _movieDbContext;

        public CreateModel(MovieDbContext movieDbContext)
        {
            _movieDbContext = movieDbContext;

            _moduleEvents = Startup.ModuleEvents;
        }

        [BindProperty]
        public Movie Movie { get; set; }

        private readonly MvcCoreSampleModuleEvents _moduleEvents;

        public async Task<IActionResult> OnPostAsync()
        {
            // Hooks to be added

            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Hooks to be added

            _movieDbContext.Add(Movie);
            await _movieDbContext.SaveChangesAsync();
            return RedirectToPage("/Index");
        }

        public void OnGet()
        {

        }
    }
}