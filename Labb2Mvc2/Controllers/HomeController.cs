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
using Labb2Mvc2.Services;

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

        public IActionResult ShowMovies(string columnToSort, bool asc, int currPage,int postsPerPage)
        {
            ListFilms model = new ListFilms();

            if (currPage == 0)
            {
                currPage = 1;
                postsPerPage = 50;
            }

            var query = _movieRepository.getAllFilms()
                .Select(x => new ListFilms.Movie { Title = x.Title, ReleaseYear = x.ReleaseYear, FilmID = x.FilmId });                

            model.pagination.currentPage = currPage;
            
            var sorter = new Sorting();

            model.Movies = sorter.SortFilms(query, columnToSort, asc)
                .Skip((currPage - 1) * postsPerPage)
                .Take(postsPerPage)
                .ToList();

            model.asc = asc;
            model.colToSort = columnToSort;

            double nrOfPosts = _movieRepository.getNrOfFilms();
            model.pagination.lastPage = (int)Math.Ceiling(nrOfPosts / postsPerPage);
            model.pagination.postsPerPage = postsPerPage;

            int counter = 1;
            foreach (ListFilms.Movie m in model.Movies)
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
