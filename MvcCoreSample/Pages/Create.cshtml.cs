using System;
using System.ComponentModel;
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
            if (_moduleEvents.PreSubmitMovie != null)
            {
                var args = new PreSubmitMovieEventArgs(Movie.Title, Movie.Rating);
                var cancel = false;
                var invocationList = _moduleEvents.PreSubmitMovie.GetInvocationList();
                foreach (Action<PreSubmitMovieEventArgs> eventModule in invocationList)
                {
                    if (!cancel)
                    {
                        eventModule(args);
                        if (args is CancelEventArgs)
                        {
                            cancel = (args as CancelEventArgs).Cancel;
                        }
                    }
                    else
                        break;
                }

                if (args.Cancel)
                {
                    if (!string.IsNullOrWhiteSpace(args.ModelErrorProperty))
                        ModelState.AddModelError("Movie" + args.ModelErrorProperty, args.ModelErrorMessage);

                    return Page();
                }

                Movie.Title = args.Title;
                Movie.Rating = args.Rating;
            }

            if (!ModelState.IsValid)
            {
                return Page();
            }

            _movieDbContext.Add(Movie);
            await _movieDbContext.SaveChangesAsync();

            // Hooks to be added
            if (_moduleEvents.MovieSubmitted != null)
            {
                var args = new MovieSubmittedEventArgs(Movie.Title, Movie.Rating);
                _moduleEvents.MovieSubmitted?.Invoke(args);
            }

            return RedirectToPage("/Index");
        }

        public void OnGet()
        {

        }
    }
}