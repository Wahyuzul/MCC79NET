using MVCArchitecture.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MVCArchitecture.Controllers
{
    internal class LinqController
    {
        public static void Menu1()
        {
            var employees = (from e in EmployeeController.GetAll()
                             join d in DepartmentController.GetAll() on e.DptID equals d.Id
                             join l in LocationController.GetAll() on d.LocationID equals l.Id
                             join c in CountryController.GetAll() on l.CtrID equals c.Id
                             join r in Region.GetAll() on c.RegionId equals r.Id
                             select new
                             {
                                 ID = e.Id,
                                 FirstName = e.firstName,
                                 LastName = e.lastName,
                                 Email = e.email,
                                 Phone = e.phone,
                                 Salary = e.salary,
                                 Department = d.Name,
                                 Address = l.StreetAdrs,
                                 Country = c.Name,
                                 Region = r.Name
                             }).Take(5);
            foreach (var emp in employees)
            {
                Console.WriteLine("===============================");
                Console.WriteLine($"ID: {emp.ID}");
                Console.WriteLine($"Full Name: {emp.FirstName} {emp.LastName}");
                Console.WriteLine($"Email: {emp.Email}");
                Console.WriteLine($"Phone: {emp.Phone}");
                Console.WriteLine($"Salary: {emp.Salary}");
                Console.WriteLine($"Department: {emp.Department}");
                Console.WriteLine($"Address: {emp.Address}");
                Console.WriteLine($"Country: {emp.Country}");
                Console.WriteLine($"Region: {emp.Region}");
                Console.WriteLine("===============================");
                Console.WriteLine();
            }
        }

        public static void Menu2()
        {
            var empDepartment = (from d in DepartmentController.GetAll()
                                 join e in EmployeeController.GetAll() on d.Id equals e.DptID into empDpt
                                 where empDpt.Count() > 3
                                 select new
                                 {
                                     DepartmentName = d.Name,
                                     TotalEmployee = empDpt.Count(),
                                     MinSalary = empDpt.Min(e => e.salary),
                                     MaxSalary = empDpt.Max(e => e.salary),
                                     AverageSalary = empDpt.Average(e => e.salary)
                                 });

            foreach (var empDpt in empDepartment)
            {
                Console.WriteLine("===============================");
                Console.WriteLine($"Department Name: {empDpt.DepartmentName}");
                Console.WriteLine($"Total Employee: {empDpt.TotalEmployee}");
                Console.WriteLine($"Lowest Salary: {empDpt.MinSalary}");
                Console.WriteLine($"Highest Salary: {empDpt.MaxSalary}");
                Console.WriteLine($"Average Salary: {empDpt.AverageSalary}");
                Console.WriteLine("===============================");
                Console.WriteLine();
            }
        }

        public static void GetMenu()
        {
            int pilihan = Convert.ToInt32(Console.ReadLine());
            switch (pilihan)
            {
                case 1:
                    Console.Clear();
                    LinqController.Menu1();
                    break;
                case 2:
                    Console.Clear();
                    LinqController.Menu2();
                    break;
                default:
                    Console.WriteLine("Input invalid");
                    break;
            }
        }
    }
}
