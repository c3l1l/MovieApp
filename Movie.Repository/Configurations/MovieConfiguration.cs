using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Repository.Configurations
{
    public class MovieConfiguration : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.Name).IsRequired().HasMaxLength(200);
           // builder.HasOne(x=>x.Director).WithMany(x=>x.Movies).HasForeignKey(x=>x.DirectorId);
           // builder.HasMany(x => x.Actors).WithMany(x => x.Movies);
           // builder.HasMany(x => x.Genres).WithMany(x => x.Movies);
           // builder.HasOne(x => x.MovieDetail).WithOne(x => x.Movie);
            

        }
    }
}
