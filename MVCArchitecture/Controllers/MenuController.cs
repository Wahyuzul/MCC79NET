using MVCArchitecture.Views;
using MVCArchitecture.Controllers;
using MVCArchitecture.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCArchitecture.Controllers
{
    internal class MenuController
    {
        public static void SelectMenu()
        {
            try
            {
                int pilihmenu = int.Parse(Console.ReadLine());
               
                switch (pilihmenu)
                {
                    case 1:
                        Console.Clear();
                        RegionController.Menu();
                        break;
                    case 2:
                        Console.Clear();
                        CountryView.Menu();
                        break;
                    case 3:
                        Console.Clear();
                        LocationView.GetAll();
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 4:
                        Console.Clear();
                        DepartmentView.GetAll();
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 5:
                        Console.Clear();
                        EmployeeView.GetAll();
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 6:
                        Console.Clear();
                        JobView.GetAll();
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 7:
                        Console.Clear();
                        Console.Clear();
                        HistoryView.GetAll();
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 8:
                        Console.Clear();
                        LinqView.Menu();
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 9:
                        System.Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Input is invalid");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();
                Console.Clear();
            }
        }


    }
}

