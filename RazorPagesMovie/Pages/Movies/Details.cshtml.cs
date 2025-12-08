using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesMovie.Data;
using RazorPagesMovie.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPagesMovie.Pages.Movies
{
    [Authorize] // or no attribute if public

    public class DetailsModel : PageModel
    {

        {
            _context = context;
        }

        public Movie Movie { get; set; } = default!;
        public double AverageRating { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _context.Movie.FirstOrDefaultAsync(m => m.Id == id);
            if (movie == null)
            {
                return NotFound();
            }
                Movie = movie;
            return Page();
        }
    }
}
