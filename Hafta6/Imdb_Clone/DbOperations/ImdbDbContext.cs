using Imdb_Clone.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Imdb_Clone.DbOperations
{
    public class ImdbDbContext : DbContext
    {
        public ImdbDbContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies(); //araştır
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MovieActor>()
                .HasKey(bc => new { bc.MovieId, bc.ActorId });
            modelBuilder.Entity<MovieActor>()
                .HasOne(bc => bc.Movie)
                .WithMany(b => b.MovieActors)
                .HasForeignKey(bc => bc.MovieId);
            modelBuilder.Entity<MovieActor>()
                .HasOne(bc => bc.Actor)
                .WithMany(c => c.MovieActors)
                .HasForeignKey(bc => bc.ActorId);
        }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Director> Directors { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<MovieActor> MovieActors { get; set; }

    }
}