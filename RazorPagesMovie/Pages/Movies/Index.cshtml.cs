using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorPagesMovie.Data;
using RazorPagesMovie.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPagesMovie.Pages.Movies
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly RazorPagesMovieContext _context;

        public IndexModel(RazorPagesMovieContext context)
        {
            _context = context;
        }

        public class MovieWithRating
        {
            public Movie Movie { get; set; } = new Movie(); // ✅ initialized
            public double AverageRating { get; set; }
        }


        public IList<MovieWithRating> Movies { get; set; } = new List<MovieWithRating>();

        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }

        public SelectList? Genres { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? MovieGenre { get; set; }

        public async Task OnGetAsync()
        {
            IQueryable<string> genreQuery = from m in _context.Movie
                                            orderby m.Genre
                                            select m.Genre;

            var allMovies = await _context.Movie.ToListAsync(); // ✅ define movies
            var ratings = await _context.Rating.ToListAsync();  // ✅ preload ratings

            Movies = allMovies.Select(m => new MovieWithRating
            {
                Movie = m,
                AverageRating = ratings
                    .Where(r => r.MovieId == m.Id)
                    .Select(r => (double)r.Stars)
                    .DefaultIfEmpty(0)
                    .Average()
            }).ToList();

            Genres = new SelectList(await genreQuery.Distinct().ToListAsync());
        }

    }
}
