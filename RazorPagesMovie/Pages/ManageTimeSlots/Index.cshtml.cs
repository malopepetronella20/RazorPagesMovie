using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesMovie.Data;
using RazorPagesMovie.Models;

namespace LapetroMovies.Pages.ManageTimeSlots;

[Authorize(Roles = "Admin")]
public class IndexModel : PageModel
{
    private readonly RazorPagesMovieContext _context;

    public IndexModel(RazorPagesMovieContext context)
    {
        _context = context;
    }

    public IList<TimeSlot> TimeSlots { get; set; } = new List<TimeSlot>();


    public async Task OnGetAsync()
    {
        TimeSlots = await _context.TimeSlot
            .Include(t => t.Movie)
            .ToListAsync();
    }
}
