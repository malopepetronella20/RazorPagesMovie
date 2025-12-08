using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesMovie.Data;
using RazorPagesMovie.Models;

namespace RazorPagesMovie.Pages.Movies
{
    public class RateModel : PageModel
    {
        private readonly RazorPagesMovieContext _context;

        public RateModel(RazorPagesMovieContext context)
        {
            _context = context;
        }

        [BindProperty]
        public int Rating { get; set; }

        public Movie? Movie { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Movie = await _context.Movie.FirstOrDefaultAsync(m => m.Id == id);

            if (Movie == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            var movie = await _context.Movie.FindAsync(id);

            if (movie == null)
            {
                return NotFound();
            }

            // You can add logic here to save the rating later

            return RedirectToPage("./Index");
        }
    }
}
