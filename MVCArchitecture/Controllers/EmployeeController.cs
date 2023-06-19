using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVCArchitecture.Models;
using MVCArchitecture.Views;

namespace MVCArchitecture.Controllers
{
    internal class EmployeeController
    {
        public static void Menu()
        {
            Employees emp = new Employees();
            EmployeeView.GetAll(emp.GetAll());
        }
    }
}
