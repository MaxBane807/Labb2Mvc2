using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Labb2Mvc2.Models;
using Microsoft.EntityFrameworkCore;

namespace Labb2Mvc2.Repositories
{
    public class MovieRepository : IMovieRepository
    {

        private sakilaContext _context;

        public MovieRepository(sakilaContext sakila)
        {
            _context = sakila;
        }
        
        
        public List<Film> getAllFilms()
        {
            var films = _context.Film.Select(x => new Film { Title = x.Title, ReleaseYear = x.ReleaseYear, FilmId = x.FilmId});

            return films.ToList();
        }
        
        public Film getByID(int id)
        {
            Film film = _context.Film.Where(x => x.FilmId == id)
                .Include(z => z.Language)
                .Select(y => new Film { Title = y.Title, Description = y.Description, Language = y.Language, Rating = y.Rating })
                .FirstOrDefault();
            return film;
        }
    }
}
