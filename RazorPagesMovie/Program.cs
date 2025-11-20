using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RazorPagesMovie.Data;

var builder = WebApplication.CreateBuilder(args);

// Add EF Core + Identity
builder.Services.AddDbContext<RazorPagesMovieContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("RazorPagesMovieContext")));

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<RazorPagesMovieContext>();

builder.Services.AddRazorPages();

var app = builder.Build();

app.UseAuthentication(); // NEW
app.UseAuthorization();

app.MapRazorPages();
app.Run();
