using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Viztangent
{
    public class ApiResponse
    {
        public string answer { get; set; } = string.Empty;
        public string status { get; set; } = string.Empty;
    }

    public class Maps
    {
        public string address { get; set; } = string.Empty; 
        public string radius { get; set; } = string.Empty;
    }
}
