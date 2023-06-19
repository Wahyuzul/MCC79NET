using MVCArchitecture.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVCArchitecture.Views;

namespace MVCArchitecture.Controllers
{
    internal class CountryController
    {
        public static void Menu()
        {
            CountryView.Menu();
        }
        public static void Edit()
        {
            try
            {
                int editcountry = int.Parse(Console.ReadLine());
                Console.WriteLine();

                switch (editcountry)
                {
                    case 1:
                        CountryView.GetById();
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 2:
                        CountryView.Insert();
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 3:
                        CountryView.Update();
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 4:
                        CountryView.Delete();
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 5:
                        Console.Clear();
                        break;
                    default:
                        Console.WriteLine("Invalid");
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
