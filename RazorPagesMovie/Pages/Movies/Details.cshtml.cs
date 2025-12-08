using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesMovie.Data;
using RazorPagesMovie.Models;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPagesMovie.Pages.Movies
{
    [Authorize]
    public class DetailsModel : PageModel
    {
        private readonly RazorPagesMovieContext _context;

        public DetailsModel(RazorPagesMovieContext context)
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

            Movie = await _context.Movie
          .Include(m => m.Ratings)
          .FirstOrDefaultAsync(m => m.Id == id) ?? new Movie();


            if (Movie == null)
            {
                return NotFound();
            }

            AverageRating = Movie.Ratings != null && Movie.Ratings.Any()
                ? Movie.Ratings.Average(r => r.Stars)
                : 0;

            return Page();
        }

    }
}
