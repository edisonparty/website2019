using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Models
{
    public class ExternalSlackResponse
    {
        public bool Ok { get; set; }
        public string Error { get; set; }
        public string Warning { get; set; }
    }
}
