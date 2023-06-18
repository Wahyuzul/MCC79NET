﻿using MVCArchitecture.Controllers;
using MVCArchitecture.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCArchitecture.Views
{
    internal class DepartmentView
    {
        public static void GetAll()
        {
            //get all departments
            Console.WriteLine("Get All Departments");
            Console.WriteLine("--------------------------");
            List<Departments> departments = Departments.GetAll();
            foreach (Departments department in departments)
            {
                Console.WriteLine("ID: " + department.Id + ", Name: " + department.Name + ", Location ID: " + department.LocationID + ", Manager ID: " + department.ManagerID);
            }
        }
    }
}
