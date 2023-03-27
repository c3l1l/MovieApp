using Microsoft.EntityFrameworkCore;
using MovieApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Repository.DbContexts
{
    public class AppDbContext:DbContext
    {
        DbSet<Movie> Movies { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {

        }
    }
}
