using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesMovie.Data;
using RazorPagesMovie.Models;

namespace LapetroMovies.Pages.ManageMovies;

[Authorize(Roles = "Admin")]
public class IndexModel : PageModel
{
    private readonly RazorPagesMovieContext _context;

    public IndexModel(RazorPagesMovieContext context)
    {
        _context = context;
    }

    public IList<Movie> Movies { get; set; } = new List<Movie>();


    public async Task OnGetAsync()
    {
        Movies = await _context.Movie.ToListAsync();
    }
    public class MovieWithRating
    {
        public Movie Movie { get; set; } = new Movie();
        public double AverageRating { get; set; }
    }

}

