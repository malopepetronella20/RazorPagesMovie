using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesMovie.Data;
using RazorPagesMovie.Models;

namespace RazorPagesMovie.Pages.Movies
{
    [Authorize(Roles = "Admin")]
    public class EditModel : PageModel
    {
        private readonly RazorPagesMovieContext _context;

        public EditModel(RazorPagesMovieContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Movie Movie { get; set; } = new Movie(); // ✅ initialized

        public IActionResult OnGet(int id)
        {
            var movie = _context.Movie.Find(id);
            if (movie == null)
            {
                return RedirectToPage("/Error");
            }

            Movie = movie;
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid) return Page();

            _context.Update(Movie); // ✅ no warning
            _context.SaveChanges();
            return RedirectToPage("/Movies/Index");
        }
    }
}
