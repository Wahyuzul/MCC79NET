using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCArchitecture.Models
{
    internal class Jobs
    {
        public string Id { get; set; }
        public string title { get; set; }
        public int minSalary { get; set; }
        public int maxSalary { get; set; }
    }
}
