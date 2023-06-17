using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCArchitecture.Models
{
    internal class Employees
    {
        public int Id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public DateTime hiredate { get; set; }
        public int salary { get; set; }
        public decimal comission { get; set; }
        public int ManagerID { get; set; }
        public string JobID { get; set; }
        public int DptID { get; set; }
    }
}
