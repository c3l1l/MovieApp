using Microsoft.Data.SqlClient;
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
    public class ActorSeed : IEntityTypeConfiguration<Actor>
    {
        public void Configure(EntityTypeBuilder<Actor> builder)
        {
            builder.HasData(
                new Actor { Id=1, FirstName="Elijah", Lastname="Wood", BirthDate=new DateTime(1981,01,28)},
                new Actor { Id=2, FirstName="Orlando", Lastname="Bloom", BirthDate=new DateTime(1977,01,13)},
                new Actor { Id=3, FirstName="Viggo", Lastname="Mortensen", BirthDate=new DateTime(1958,10,20)},
                new Actor { Id=4, FirstName="Leonardo", Lastname="DicCaprio", BirthDate=new DateTime(1974,11,11)},
                new Actor { Id=5, FirstName="Christian", Lastname="Bale", BirthDate=new DateTime(1974,01,30)}
                ) ;
        }
    }
}
