using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCArchitecture.Models
{
    internal class Countries
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int RegionId { get; set; }

    }
}
