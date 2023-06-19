using MVCArchitecture.Controllers;
using MVCArchitecture.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCArchitecture.Views
{
    internal class JobView
    {
        public static void List(List<Jobs> jobs)
        {
            //get all locations
            Console.WriteLine("Get All Jobs");
            Console.WriteLine("--------------------------");
            foreach (Jobs job in jobs)
            {
                Console.WriteLine("ID: " + job.Id + ", Title: " + job.title + ", min salary: " + job.minSalary + ", max salary: " + job.maxSalary);
            }
        }
    }
}
