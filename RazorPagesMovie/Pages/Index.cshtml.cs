using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesMovie.Data;
using RazorPagesMovie.Models;

public class IndexModel : PageModel
{
    public MovieCarouselViewModel TrendingMovies { get; set; }
    public MovieCarouselViewModel FeaturedMovies { get; set; }

    private readonly MovieContext _context;

    public IndexModel(MovieContext context)
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
