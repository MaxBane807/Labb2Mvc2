using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Labb2Mvc2.Models;

namespace Labb2Mvc2.Repositories
{
    public interface IMovieRepository
    {
        public IEnumerable<Film> getAllFilms();

        public Film getByID(int id);

        public int getNrOfFilms();
    }
}
