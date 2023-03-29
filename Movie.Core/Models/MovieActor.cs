using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Core.Models
{
    public class MovieActor:BaseEntity
    {
        public int ActorId { get; set; }
        public int MovieId { get; set; }
        public virtual Movie Movie { get; set; }
        public virtual Actor Actor { get; set; }
    }
}
