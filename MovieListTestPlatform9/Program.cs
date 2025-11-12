using MovieListTestPlatform9.Domains.Data;
using MovieListTestPlatform9.Services;
using MovieListTestPlatform9.Services.Interfaces;
using Microsoft.EntityFrameworkCore; 

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<MovieDbContext>(options => 
    options.UseInMemoryDatabase("MovieListDb"));

builder.Services.AddTransient<IMovieService, MovieService>();
builder.Services.AddTransient<IDataPersistanceService, DataPersistanceService>();
builder.Services.AddScoped<IMovieListService, MovieListService>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dataService = scope.ServiceProvider.GetRequiredService<IDataPersistanceService>();
    await dataService.LoadDataAsync();
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Movie}/{action=Index}/{id?}")
    .WithStaticAssets();

app.Run();
