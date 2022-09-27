using AttendanceTracking.Models;
using AttendanceTracking.Models.Repositories;
using AttendanceTracking.Service;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AttendanceTrackingDbContext>(x => x.UseSqlServer(
    builder.Configuration.GetConnectionString("SystemConnection")
    ));
builder.Services.AddTransient<StudentsRepository>();

// Setting identity system
builder.Services.AddIdentity<IdentityUser, IdentityRole>(opts =>
{
    opts.User.RequireUniqueEmail = true;
    opts.Password.RequiredLength = 6;
    opts.Password.RequireNonAlphanumeric = false;
    opts.Password.RequireLowercase = false;
    opts.Password.RequireUppercase = false;
    opts.Password.RequireDigit = true;
}).AddEntityFrameworkStores<AttendanceTrackingDbContext>().AddDefaultTokenProviders();

// Setting authentifiaction cookie
builder.Services.ConfigureApplicationCookie(options =>
{
    options.Cookie.Name = "attendanceTracking";
    options.Cookie.HttpOnly = true;
    options.LoginPath = "/Account/Login";
    options.AccessDeniedPath = "/Account/Accessdenied";
    options.SlidingExpiration = true;
});

// Setting authorisation policy for Admin area
builder.Services.AddAuthorization(x =>
{
    x.AddPolicy("AdminArea", policy => { policy.RequireRole("admin"); });
});

// Added services for Controllers and Views
builder.Services.AddControllersWithViews(x =>
{
    x.Conventions.Add(new AdminAreaAuthorization("Admin", "AdminArea"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// Authorization and Authentication
app.UseCookiePolicy();
app.UseAuthentication();
app.UseAuthorization();

/*app.MapControllerRoute(
    name: "Admin",
    pattern: "{area:exists}/{controller=Students}/{action=Index}/{id?}");*/

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Journal}/{action=List}/{id?}");

app.Run();
