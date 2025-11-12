using Microsoft.EntityFrameworkCore;
using MovieListTestPlatform9.Domains.Data;
using MovieListTestPlatform9.Domains.Entities;
using MovieListTestPlatform9.Services.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieListTestPlatform9.Services
{
    public class DataPersistanceService : IDataPersistanceService
    {
        private readonly MovieDbContext _Db;
        private readonly string _filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "Data", "Data");


        public DataPersistanceService(MovieDbContext db)
        {
            _Db = db;
        }

        public async Task LoadDataAsync()
        {
            if (!File.Exists(_filePath))
            {
                return;
            }
            var json = await File.ReadAllTextAsync(_filePath);
            var movies = JsonConvert.DeserializeObject<List<Movie>>(json);

            if (movies != null)
            {
                foreach (var movie in movies)
                {
                    if(!_Db.Movies.Any(m => m.Id == movie.Id))
                    {
                        _Db.Movies.Add(movie);
                    }
                }
                await _Db.SaveChangesAsync();
            }
        }

        public async Task SaveDataAsync()
        {
            // Zorg dat de directory bestaat
            var directory = Path.GetDirectoryName(_filePath);
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            var movies = await _Db.Movies.ToListAsync();
            var json = JsonConvert.SerializeObject(movies);
            await File.WriteAllTextAsync(_filePath, json);
        }

    }
}
