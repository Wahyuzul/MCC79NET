using MVCArchitecture.Controllers;
using MVCArchitecture.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCArchitecture.Views
{
    internal class EmployeeView
    {
        public static void List(List<Employees> employees)
        {
            //get all employees
            Console.WriteLine("Get All Employees");
            foreach (Employees employee in employees)
            {
                Console.WriteLine("=======================================");
                Console.WriteLine("ID: " + employee.Id);
                Console.WriteLine("First Name: " + employee.firstName);
                Console.WriteLine("Last Name: " + employee.lastName);
                Console.WriteLine("Email: " + employee.email);
                Console.WriteLine("Phone: " + employee.phone);
                Console.WriteLine("Hire date: " + employee.hiredate);
                Console.WriteLine("Salary: " + employee.salary);
                Console.WriteLine("Comission: " + employee.comission);
                Console.WriteLine("Manager ID: " + employee.ManagerID);
                Console.WriteLine("Job ID: " + employee.JobID);
                Console.WriteLine("Department ID: " + employee.DptID);
                Console.WriteLine("=======================================");
                Console.WriteLine();
            }
        }
    }
}
