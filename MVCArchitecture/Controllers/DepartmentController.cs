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
    internal class DepartmentController
    {
        public static void Menu()
        {
            Departments dept = new Departments();
            DepartmentView.List(dept.GetAll());
        }
    }
}
