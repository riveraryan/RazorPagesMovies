using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorPagesMovies.Data;
using RazorPagesMovies.Models;

namespace RazorPagesMovies.Pages.Movies
{
    public class IndexModel : PageModel
    {
        private readonly RazorPagesMovies.Data.RazorPagesMoviesContext _context;

        public IndexModel(RazorPagesMovies.Data.RazorPagesMoviesContext context)
        {
            _context = context;
        }

        public IList<Movie> Movie { get;set; }
        [BindProperty(SupportsGet = true)] //Not supported by get request by default
        public string SearchString { get; set; }
        public SelectList Genres { get; set; }
        [BindProperty(SupportsGet = true)] //Not supported by get request by default
        public string MovieGenre { get; set; }

        public async Task OnGetAsync()
        {
            // Use LINQ to get list of genres.
            IQueryable<string> genreQuery = from m in _context.Movie
                                            orderby m.genre
                                            select m.genre;
            // Use LINQ to get list of movies
            var movies = from m in _context.Movie
                         select m;

            if (!string.IsNullOrEmpty(SearchString))
            {
                //the query is modified to filter on the SearchString
                movies = movies.Where(s => s.Title.Contains(SearchString));
            }

            if (!string.IsNullOrEmpty(MovieGenre))
            {
                //the query is modified to filter on the MovieGenre
                movies = movies.Where(x => x.genre == MovieGenre);
            }
            Genres = new SelectList(await genreQuery.Distinct().ToListAsync());
            Movie = await movies.ToListAsync();
        }
    }
}
