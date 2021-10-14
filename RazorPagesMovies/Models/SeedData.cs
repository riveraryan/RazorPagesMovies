using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RazorPagesMovies.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPagesMovies.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new RazorPagesMoviesContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<RazorPagesMoviesContext>>()))
            {
                // Look for any movies.
                if (context.Movie.Any())
                {
                    return;   // DB has been seeded
                }

                context.Movie.AddRange(
                    new Movie
                    {
                        Title = "When Harry Met Sally",
                        ReleaseDate = DateTime.Parse("1989-2-12"),
                        genre = "Romantic Comedy",
                        Price = 7.99M,
                        Rating = "R"
                    },

                    new Movie
                    {
                        Title = "Ghostbusters ",
                        ReleaseDate = DateTime.Parse("1984-3-13"),
                        genre = "Comedy",
                        Price = 8.99M,
                        Rating = "PG-13"
                    },

                    new Movie
                    {
                        Title = "Ghostbusters 2",
                        ReleaseDate = DateTime.Parse("1986-2-23"),
                        genre = "Comedy",
                        Price = 9.99M,
                        Rating = "PG-13"
                    },

                    new Movie
                    {
                        Title = "Rio Bravo",
                        ReleaseDate = DateTime.Parse("1959-4-15"),
                        genre = "Western",
                        Price = 3.99M,
                        Rating = "PG"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
