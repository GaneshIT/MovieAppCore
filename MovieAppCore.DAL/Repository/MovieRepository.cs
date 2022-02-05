using MovieAppCore.DAL.Data;
using MovieAppCore.Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace MovieAppCore.DAL.Repository
{
    public class MovieRepository : IMovieRepository
    {
        MovieDbContext _movieDbContext;
        public MovieRepository(MovieDbContext movieDbContext)
        {
            _movieDbContext = movieDbContext;
        }
        public void AddMovie(Movie movie)
        {
            _movieDbContext.movie.Add(movie);
            _movieDbContext.SaveChanges();
        }

        public void DeleteMovie(int movieId)
        {
            var movie = _movieDbContext.movie.Find(movieId);
            _movieDbContext.movie.Remove(movie);
            _movieDbContext.SaveChanges();
        }

        public Movie GetMovieById(int movieId)
        {
            return _movieDbContext.movie.Find(movieId);
        }

        public IEnumerable<Movie> GetMovies()
        {
            return _movieDbContext.movie.ToList();
        }

        public void UpdateMovie(Movie movie)
        {
            _movieDbContext.Entry(movie).State = EntityState.Modified;
            _movieDbContext.SaveChanges();
        }
    }
}
