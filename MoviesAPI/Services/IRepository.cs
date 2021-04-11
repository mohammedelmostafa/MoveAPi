using MoviesAPI.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesAPI.Services
{
    public interface IRepository
    {
        void addGenre(Genre genre);
        Task<List<Genre>> GetAllGenres();
        Genre GetGenreById(int id);
    }
}
