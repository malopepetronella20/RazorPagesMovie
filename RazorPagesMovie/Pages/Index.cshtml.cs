using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesMovie.Models;
using RazorPagesMovie.Data;

namespace RazorPagesMovie.Pages
{
    public class IndexModel : PageModel
    {
        public MovieCarouselViewModel TrendingMovies { get; set; } = new MovieCarouselViewModel();
        public MovieCarouselViewModel FeaturedMovies { get; set; } = new MovieCarouselViewModel();

        private readonly RazorPagesMovieContext _context;

        public IndexModel(RazorPagesMovieContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
            TrendingMovies = new MovieCarouselViewModel
            {
                Title = "🔥 Trending Now",
                Movies = _context.Movie.Take(10).ToList()
            };

            FeaturedMovies = new MovieCarouselViewModel
            {
                Title = "🎥 Featured Movies",
                Movies = _context.Movie.Skip(10).Take(6).ToList()
            };
        }
    }
}
