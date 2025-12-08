using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RazorPagesMovie.Data;

var builder = WebApplication.CreateBuilder(args);

// Register RazorPagesMovieContext for your Movies pages
builder.Services.AddDbContext<RazorPagesMovieContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("RazorPagesMovieContext")));

// Register ApplicationDbContext for Identity
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddDefaultIdentity<IdentityUser>(options =>
{
    options.SignIn.RequireConfirmedAccount = false; // set true if you want email confirmation
})
.AddRoles<IdentityRole>() // enable roles
.AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddRazorPages();

var app = builder.Build();

// Middleware pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

// ✅ Seed roles and default admin account
using (var scope = app.Services.CreateScope())
{
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();

    await SeedRolesAndAdminAsync(roleManager, userManager);
}

app.Run();

// ----------------- Helper Method -----------------
static async Task SeedRolesAndAdminAsync(RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager)
{
    // Create roles if they don't exist
    if (!await roleManager.RoleExistsAsync("Admin"))
        await roleManager.CreateAsync(new IdentityRole("Admin"));
    if (!await roleManager.RoleExistsAsync("User"))
        await roleManager.CreateAsync(new IdentityRole("User"));

    // Create default admin account if it doesn't exist
    var adminEmail = "admin@lapetro.com";
    var adminPassword = "Admin@123"; // ✅ Define a strong default password

    var adminUser = await userManager.FindByEmailAsync(adminEmail);

    if (adminUser == null)
    {
        adminUser = new IdentityUser
        {
            UserName = adminEmail,
            Email = adminEmail,
            EmailConfirmed = true
        };
        await userManager.CreateAsync(adminUser, adminPassword);
        await userManager.AddToRoleAsync(adminUser, "Admin");
    }
}
