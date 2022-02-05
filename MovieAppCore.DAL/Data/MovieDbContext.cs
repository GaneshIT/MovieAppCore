using Microsoft.EntityFrameworkCore;
using MovieAppCore.Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieAppCore.DAL.Data
{
    public class MovieDbContext:DbContext
    {
        public MovieDbContext(DbContextOptions<MovieDbContext> options):base(options)
        {

        }
        public DbSet<Movie> movie { get; set; }

        public DbSet<MovieShowTimings> movieShowTimings { get; set; }
        public DbSet<UserInfo> userInfo { get; set; }
    }
}
