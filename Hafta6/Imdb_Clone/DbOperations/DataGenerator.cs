﻿using Imdb_Clone.Entities;
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
                        Year= "2001",
                        Actors= "lotrActors",
                        DirectorId = 1,
                        GenreId = 1,

                    },
                    new Movie
                    {
                        Name = "Schindler's List",
                        Year = "1993",
                        Actors = "slActors",
                        DirectorId = 2,
                        GenreId = 2
                    },
                    new Movie
                    {
                        Name = "Sully",
                        Year = "2016",
                        Actors = "SA",
                        DirectorId = 3,
                        GenreId = 2,

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
                    },
                    new Director
                    { 
                        Name="Clint",
                        Surname="Eastwood"
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
                    },
                    new Actor
                    {
                        Name="Liam",
                        Surname="Neeson"
                    },
                    new Actor
                    {
                        Name="Ralph",
                        Surname="Fiennes"
                    },
                    new Actor
                    {
                        Name="Ben",
                        Surname="Kingsley"
                    },
                    new Actor
                    {
                        Name="Tom",
                        Surname="Hanks"
                    },
                    new Actor
                    {
                        Name="Aaron",
                        Surname="Eckhart"
                    }
                    );

                context.SaveChanges();

            }
        }


    }
}
