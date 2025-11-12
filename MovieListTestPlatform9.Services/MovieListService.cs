using Microsoft.EntityFrameworkCore;
using MovieListTestPlatform9.Domains.Data;
using MovieListTestPlatform9.Domains.Entities;
using MovieListTestPlatform9.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieListTestPlatform9.Services
{
    public class MovieListService : IMovieListService
    {
        private readonly MovieDbContext _db;
        private readonly IDataPersistanceService _dataService;

        public MovieListService(MovieDbContext db, IDataPersistanceService dataService)
        {
            _db = db;
            _dataService = dataService;
        }
        
        public async Task AddMovieAsync(Movie movie)
        {
            if(!await _db.Movies.AnyAsync(m => m.Id == movie.Id))
            {
                _db.Movies.Add(movie);
                await _db.SaveChangesAsync();
                await _dataService.SaveDataAsync();
            }
        }

        public async Task<List<Movie>> GetAllMoviesAsync()
        {
            return await _db.Movies.ToListAsync();
        }

        public async Task RemoveMovieAsync(Movie movie)
        {
            var existing = await _db.Movies.FirstOrDefaultAsync(m => m.Id == movie.Id);
            if (existing != null)
            {
                _db.Movies.Remove(existing);
                await _db.SaveChangesAsync();
                await _dataService.SaveDataAsync();
            }
        }

        public async Task SaveChangesAsync()
        {
            await _db.SaveChangesAsync();
            await _dataService.SaveDataAsync(); // indien je JSON gebruikt
        }

    }
}
