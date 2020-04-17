using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Labb2Mvc2.Models;

namespace Labb2Mvc2.Repositories
{
    public class CashedMovieRepository : IMovieRepository
    {
        private readonly IMovieRepository _repo;
        static DateTime _lastfetched;
        static Film _film;
        
        public CashedMovieRepository(IMovieRepository repo)
        {
            _repo = repo;
        }
        
        public IEnumerable<Film> getAllFilms()
        {
            return _repo.getAllFilms();
        }

        public Film getByID(int id)
        {
            var timepassed = DateTime.Now - _lastfetched;
            var secondsspassed = timepassed.TotalSeconds;

            if (secondsspassed > 60)
            {
                _lastfetched = DateTime.Now;
                _film = _repo.getByID(id);
            }
            return _film;
        }

        public int getNrOfFilms()
        {
            return _repo.getNrOfFilms();
        }
    }
}
