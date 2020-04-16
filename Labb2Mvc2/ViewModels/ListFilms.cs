using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Labb2Mvc2.ViewModels
{
    public class ListFilms
    {
        public Pagination pagination { get; set; } = new Pagination();
        
        public List<Movie> Movies { get; set; }

        public string colToSort { get; set; }

        public bool asc { get; set; }
      
        public class Movie
        {
            public int Nr { get; set; }

            public int FilmID { get; set; }

            public string Title { get; set; }

            public string ReleaseYear { get; set; }
        }
    }
}
