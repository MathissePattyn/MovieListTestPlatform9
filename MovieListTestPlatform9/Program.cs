using Microsoft.EntityFrameworkCore;
using MovieListTestPlatform9.Domains.Data;
using MovieListTestPlatform9.Services;
using MovieListTestPlatform9.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Voeg MVC services toe (Controllers + Views)
builder.Services.AddControllersWithViews();

// Gebruik je bestaande DbContext, hier met InMemoryDatabase
builder.Services.AddDbContext<MovieDbContext>(options =>
    options.UseInMemoryDatabase("MovieListDb"));

// Voeg je services toe
builder.Services.AddTransient<IMovieService, MovieService>();
builder.Services.AddTransient<IDataPersistanceService, DataPersistanceService>();
builder.Services.AddScoped<IMovieListService, MovieListService>();

var app = builder.Build();

// Laad dummy data
using (var scope = app.Services.CreateScope())
{
    var dataService = scope.ServiceProvider.GetRequiredService<IDataPersistanceService>();
    await dataService.LoadDataAsync();
}

// Middleware
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// Geen authentication/authorization meer

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Movie}/{action=Index}/{id?}");

app.Run();
