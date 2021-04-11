using MoviesAPI.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesAPI.Services
{
    public class InmemoryRepository:IRepository
    {
        private List<Genre> _genres;
        public InmemoryRepository()
        {
            _genres = new List<Genre>()
            {
                new Genre(){Id=1,Name="comedy"},
                new Genre(){Id=2,Name="Action"}
            };
        }

        public async Task<List<Genre>> GetAllGenres()
        {
            await Task.Delay(3000);
            return _genres;
        }

        public Genre GetGenreById(int id)
        {
            return _genres.FirstOrDefault(x => x.Id == id);
        }

        public void addGenre(Genre genre)
        {
            genre.Id = _genres.Max(x => x.Id) + 1;
            _genres.Add(genre);
        }
    }
}
