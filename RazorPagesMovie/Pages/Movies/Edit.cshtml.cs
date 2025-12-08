using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorPagesMovie.Data;
using RazorPagesMovie.Models;

namespace RazorPagesMovie.Pages.Movies
{
    [Authorize(Roles = "Admin")]
    public class EditModel : PageModel
    {

        {
            _context = context;
        }

        [BindProperty]

        {
            if (movie == null)
            {
            }

            Movie = movie;
            return Page();
        }

        {

        }
    }
}
