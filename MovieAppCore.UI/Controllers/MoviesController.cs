﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using MovieAppCore.Entity.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;


namespace MovieAppCore.UI.Controllers
{
    public class MoviesController : Controller
    {
        private IConfiguration _configuration;
        public MoviesController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<IActionResult> Index()        
        {
            IEnumerable<Movie> movieresult = null;
            using (HttpClient client = new HttpClient())
            {
                string endPoint = _configuration["WebApiBaseUrl"] + "Movies/GetMovies";
                using (var response =await client.GetAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        movieresult = JsonConvert.DeserializeObject<IEnumerable<Movie>>(result);
                    }
                }
            }
            return View(movieresult);
        }
        public IActionResult MovieEntry()
        {
            List<SelectListItem> language = new List<SelectListItem>()
            {
                new SelectListItem{Value="Select",Text="select"},
                new SelectListItem{Value="Tamil",Text="Tamil"},
                new SelectListItem{Value="English",Text="English"},
                new SelectListItem{Value="Kannada",Text="Kannada"},
            };
            ViewBag.languagelist = language;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> MovieEntry(Movie movie)
        {
            if (ModelState.IsValid)
            {
                ViewBag.status = "";
                if (Request.Form.Files.Count > 0)
                {
                    MemoryStream ms = new MemoryStream();
                    Request.Form.Files[0].CopyTo(ms);
                    movie.ImgPoster = ms.ToArray();
                }
                using (HttpClient client = new HttpClient())
                {
                    StringContent content = new StringContent(JsonConvert.SerializeObject(movie), Encoding.UTF8, "application/json");
                    string endPoint = _configuration["WebApiBaseUrl"] + "Movies/AddMovie";
                    using (var response = await client.PostAsync(endPoint, content))
                    {
                        if (response.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            ViewBag.status = "Ok";
                            ViewBag.message = "Movie details saved successfully!";
                        }
                        else
                        {
                            ViewBag.status = "Error";
                            ViewBag.message = "Wrong entries!";
                        }
                    }
                }
            }
            return View();
        }

        public async Task<IActionResult> EditMovie(int MovieId)
        {
            List<SelectListItem> language = new List<SelectListItem>()
            {
                new SelectListItem{Value="Select",Text="select"},
                new SelectListItem{Value="Tamil",Text="Tamil"},
                new SelectListItem{Value="English",Text="English"},
                new SelectListItem{Value="Kannada",Text="Kannada"},
            };
            ViewBag.languagelist = language;
            Movie movie = null;
            using (HttpClient client = new HttpClient())
            {
                string endPoint = _configuration["WebApiBaseUrl"] + "Movies/GetMovieById?movieId="+MovieId;
                using (var response = await client.GetAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        movie = JsonConvert.DeserializeObject<Movie>(result);
                    }
                }
            }
            return View(movie);
        }

        [HttpPost]
        public async Task<IActionResult> EditMovie(Movie movie)
        {
            ViewBag.status = "";
            if (Request.Form.Files.Count > 0)
            {
                MemoryStream ms = new MemoryStream();
                Request.Form.Files[0].CopyTo(ms);
                movie.ImgPoster = ms.ToArray();
            }
            using (HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(movie), Encoding.UTF8, "application/json");
                string endPoint = _configuration["WebApiBaseUrl"] + "Movies/UpdateMovie";
                using (var response = await client.PostAsync(endPoint, content))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        ViewBag.status = "Ok";
                        ViewBag.message = "Movie details saved successfully!";
                    }
                    else
                    {
                        ViewBag.status = "Error";
                        ViewBag.message = "Wrong entries!";
                    }
                }
            }
            return View();
        }
        public IActionResult DeleteMovie(int MovieId)
        {
            return View();
        }

    }
}
 