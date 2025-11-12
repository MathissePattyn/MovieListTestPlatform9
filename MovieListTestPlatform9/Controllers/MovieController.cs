using Microsoft.AspNetCore.Mvc;
using MovieListTestPlatform9.Domains.Entities;
using MovieListTestPlatform9.Services.Interfaces;
using MovieListTestPlatform9.ViewModels;

namespace MovieListTestPlatform9.Controllers
{
    public class MovieController : Controller
    {

        public IMovieService _MovieService;
        public IMovieListService _MovieListService;

        public MovieController(IMovieService movieService, IMovieListService movieListService)
        {
            _MovieService = movieService;
            _MovieListService = movieListService;
        }

        public async Task<IActionResult> Index()
        {
            var movies = await _MovieListService.GetAllMoviesAsync();
            return View(movies);
        }

        public async Task<IActionResult> Search(String zoekterm)
        {
            var vm = new MovieSearchVM()
            {
                zoekterm = zoekterm ?? string.Empty
            };
            if (!string.IsNullOrEmpty(zoekterm))
            {
                try
                {
                    vm.Movies = await _MovieService.SearchMoviesAsync(zoekterm);
                    var SavedMovies = await _MovieListService.GetAllMoviesAsync();
                    vm.SavedMovies = SavedMovies;
                }
                catch
                {
                    vm.ErrorMessage = "Fout bij zoeken films";
                }
            }
            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Search(MovieSearchVM vm)
        {
            try
            {
                vm.Movies = await _MovieService.SearchMoviesAsync(vm.zoekterm);
                var SavedMovies = await _MovieListService.GetAllMoviesAsync();
                vm.SavedMovies = SavedMovies;
            }
            catch
            {
                vm.ErrorMessage = "fout bij zoeken van films";
            }

            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> AddToList(Movie movie, string zoekterm)
        {
            if (movie != null)
            {
                await _MovieListService.AddMovieAsync(movie);
                
            }
            return RedirectToAction("Search", new {zoekterm});
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Remove(String id, String zoekterm)
        {
            if (id != null)
            {
                var movie = (await _MovieListService.GetAllMoviesAsync()).FirstOrDefault(m => m.Id == id);
                if(movie != null)
                {
                    await _MovieListService.RemoveMovieAsync(movie);
                }
            }
            if (!string.IsNullOrEmpty(zoekterm))
            {
                return RedirectToAction("Search", new { zoekterm });
            }
            return Redirect("Index");
        }

        
    }
}
