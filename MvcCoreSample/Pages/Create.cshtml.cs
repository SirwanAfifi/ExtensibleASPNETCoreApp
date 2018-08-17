﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MvcCoreSample.DataLayer;
using MvcCoreSample.DomainClasses;

namespace MvcCoreSample.Pages
{
    public class CreateModel : PageModel
    {
        private readonly MovieDbContext _movieDbContext;

        public CreateModel(MovieDbContext movieDbContext)
        {
            _movieDbContext = movieDbContext;
        }

        [BindProperty]
        public Movie Movie { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _movieDbContext.Add(Movie);
            await _movieDbContext.SaveChangesAsync();
            return RedirectToPage("/Index");
        }

        public void OnGet()
        {

        }
    }
}