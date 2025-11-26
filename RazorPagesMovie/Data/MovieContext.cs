using Microsoft.EntityFrameworkCore;
using RazorPagesMovie.Models;

namespace RazorPagesMovie.Data
{
    public class MovieContext : DbContext
    {
        public DbSet<Movie> Movie { get; set; } = default!;
    }
}
