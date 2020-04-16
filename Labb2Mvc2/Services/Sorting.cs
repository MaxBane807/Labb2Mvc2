using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Labb2Mvc2.Models;
using Labb2Mvc2.ViewModels;

namespace Labb2Mvc2.Services
{
    public class Sorting
    {
        public IEnumerable<ListFilms.Movie> SortFilms(IEnumerable<ListFilms.Movie> films,string columnToSort,bool asc)
        {
            if (columnToSort == null)
            {
                columnToSort = "Title";
                asc = false;
            }

            switch (columnToSort)
            {
                case "Title":
                    if (asc) return films.OrderBy(x => x.Title);
                    else return films.OrderByDescending(x => x.Title);

                default:
                    if (asc) return films.OrderBy(x => x.ReleaseYear);
                    else return films.OrderByDescending(x => x.ReleaseYear);
            }
        
        }
    }
}
