using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Repository.Seeds
{
    public class MovieSeed : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {

            builder.HasData(
                new Movie
                {
                    Id = 1,DirectorId = 1,Name="Lord Of The Rings 1- The Fellowship Of The Ring"
                },
                 new Movie
                 {
                     Id = 2,
                     DirectorId = 1,
                     Name = "Lord Of The Rings 2- The Two Towers"
                 },
                  new Movie
                  {
                      Id = 3,
                      DirectorId = 1,
                      Name = "Lord Of The Rings 3- The Return Of The King"
                  },
                   new Movie
                   {
                       Id = 4,
                       DirectorId = 2,
                       Name = "The Dark Knight"
                   },
                    new Movie
                    {
                        Id = 5,
                        DirectorId = 2,
                        Name = "Inception"
                    }
                );
        }
    }
}
