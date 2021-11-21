using Imdb_Clone.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Imdb_Clone.DbOperations
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ImdbDbContext(serviceProvider.GetRequiredService<DbContextOptions<ImdbDbContext>>()))
            {
                if (context.Movies.Any())
                {
                    return;
                }

                context.Movies.AddRange(
                    new Movie
                    {
                        Name= "Lord of the Rings",
                        Year= new DateTime(2001)
                    },
                    new Movie
                    {
                        Name = "Schindler's List",
                        Year = new DateTime(1993)
                    }
                    );

                context.Genres.AddRange(
                    new Genre
                    {
                        Name="Fantastic"
                    },
                    new Genre
                    {
                        Name= "History"
                    }
                    );

                context.Directors.AddRange(
                    new Director
                    {
                        Name="Steven",
                        Surname="Spielberg"
                    },
                    new Director
                    {
                        Name="Peter",
                        Surname="Jackson"
                    }
                    );

                context.Actors.AddRange(
                    new Actor
                    {
                        Name="Elijah",
                        Surname="Wood"
                    },
                    new Actor
                    {
                        Name="Ian",
                        Surname="McKellen"
                    },
                    new Actor
                    {
                        Name="Orlando",
                        Surname="Bloom"
                    }
                    );

                context.SaveChanges();

            }
        }


    }
}
