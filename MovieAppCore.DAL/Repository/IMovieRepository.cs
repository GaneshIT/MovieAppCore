using MovieAppCore.Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieAppCore.DAL.Repository
{
   public interface IMovieRepository
    {
        void AddMovie(Movie movie);
        void UpdateMovie(Movie movie);
        void DeleteMovie(int movieId);
        Movie GetMovieById(int movieId);
        IEnumerable<Movie> GetMovies();

    }
}
