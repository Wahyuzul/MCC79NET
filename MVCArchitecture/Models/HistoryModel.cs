using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCArchitecture.Models
{
    internal class Histories
    {
        public DateTime startDate { get; set; }
        public int Id { get; set; }
        public DateTime? endDate { get; set; }
        public int dptID { get; set; }
        public string jobID { get; set; }
    }
}
