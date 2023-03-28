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
    public class DirectorSeed : IEntityTypeConfiguration<Director>
    {
        public void Configure(EntityTypeBuilder<Director> builder)
        {
            builder.HasData(
                new Director { Id=1, FirstName="Peter", LastName="Jackson"},
                new Director { Id=2, FirstName="Christopher", LastName="Nolan"},
                new Director { Id=3, FirstName="Chris", LastName="Columbus"}

                );
        }
    }
}
