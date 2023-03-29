using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Core.Models
{
    public class Actor:BaseEntity
    {
        public string FirstName { get; set; }
        public string Lastname { get; set; }
        public DateTime? BirthDate { get; set; }
        public virtual ICollection<MovieActor>? MovieActors { get; set; }

    }
}
