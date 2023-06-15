
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBConnectivity
{
    internal class LINQ
    {
        public static void Menu()
        {
            var employees = (from e in Employees.GetAllEmployee()
                             join d in Departments.GetAllDepartment() on e.DptID equals d.Id
                             join l in Locations.GetAllLocation() on d.LocationID equals l.Id
                             join c in Countries.GetAllCountry() on l.CtrID equals c.Id
                             join r in Region.GetAllRegion() on c.RegionId equals r.Id
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
            var empDepartment = (from d in Departments.GetAllDepartment()
                                join e in Employees.GetAllEmployee() on d.Id equals e.DptID into empDpt where empDpt.Count() > 3
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
    }
}
