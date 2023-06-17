using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCArchitecture.Models
{
    public class Locations
    {
        public int Id { get; set; }
        public string StreetAdrs { get; set; }
        public string Postal { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string CtrID { get; set; }
    }
}
