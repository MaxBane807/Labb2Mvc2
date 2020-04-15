using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Labb2Mvc2.Models;
using Labb2Mvc2.Repositories;
using Labb2Mvc2.ViewModels;

namespace Labb2Mvc2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMovieRepository _movieRepository;

        public HomeController(ILogger<HomeController> logger, IMovieRepository movies)
        {
            _logger = logger;
            _movieRepository = movies;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ShowMovies(string columnToSort, bool asc)
        {
            ListFilms model = new ListFilms();

            model.Movies = _movieRepository.getAllFilms()
                .Select(x => new ListFilms.Movie { Title = x.Title, ReleaseYear = x.ReleaseYear, FilmID = x.FilmId }).ToList();

            if (columnToSort == null)
            {
                columnToSort = "Title";
                asc = false;
            }
            
            if (columnToSort == "Title")
            {
                if (asc) 
                {
                    model.Movies = model.Movies.OrderBy(x => x.Title).ToList();
                }
                else
                {
                    model.Movies = model.Movies.OrderByDescending(x => x.Title).ToList();
                }
            }
            else
            {
                if (asc)
                {
                    model.Movies = model.Movies.OrderBy(x => x.ReleaseYear).ToList();
                }
                else
                {
                    model.Movies = model.Movies.OrderByDescending(x => x.ReleaseYear).ToList();
                }
            }

            model.asc = asc;
            
            int counter = 1;
            foreach (var m in model.Movies)
            {
                m.Nr = counter;
                counter++;
            }

            return View(model);
        }

        public IActionResult MovieDetails(int id)
        {
            Film data = _movieRepository.getByID(id);

            FilmDetails model = new FilmDetails { Title = data.Title, Description = data.Description, Language = data.Language.Name, Rating = data.Rating };

            return View(model);
        }

        

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
