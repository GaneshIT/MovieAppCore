﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieAppCore.BAL.services;
using MovieAppCore.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//Test
namespace MovieAppCoreApi.Controllers
{
    //localhost:23232/api/movies/GetMovies
    /// <summary>
    
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private MovieService _movieService;
        public MoviesController(MovieService movieService)
        {
            _movieService = movieService;
        }
        [Authorize(Roles = "Admin")]
        [HttpGet("GetMovies")]
        public IEnumerable<Movie> GetMovies()
        {
           return _movieService.GetMovies();
        }
        [HttpGet("GetMovieById")]
        public Movie GetMovieById(int movieId)
        {
            return _movieService.GetMovieByid(movieId);
        }

        [HttpPost("AddMovie")]
        public IActionResult AddMovie([FromBody]Movie movie)
        {
            _movieService.AddMoive(movie);
            return Ok("Movie created successfully!!");
        }

        [HttpDelete("DeleteMovie")]  
        public IActionResult DeleteMovie(int movieId)
        {
            _movieService.DeleteMovie(movieId);
            return Ok("Movie deleted successfully!!");
        }

        [HttpPut("UpdateMovie")]
        public IActionResult UpdateMovie([FromBody] Movie movie)
        {
            _movieService.UpdateMoive(movie);
            return Ok("Movie updated successfully!!");
        }
    }
}

//POSTMAN tool - API Testing tool
