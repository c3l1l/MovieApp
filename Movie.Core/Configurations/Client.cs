using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Core.Configurations
{
    public class Client
    {
        public string Id { get; set; }
        public string Secret { get; set; }
        //www.myapi1.com www.myapi2.com
        public List<string> Audiences { get; set; }
    }
}
