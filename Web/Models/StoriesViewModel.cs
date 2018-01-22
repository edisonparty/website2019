using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Models
{
    public class StoriesViewModel
    {
        public StoriesViewModel()
        {
            Stories = new List<Story>();
        }
        public List<Story> Stories { get; set; }
    }
}
