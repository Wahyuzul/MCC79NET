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
    public class RegionController
    {

        public static void Menu()
        {
            RegionView.Menu();
        }
        
        public static void Edit()
        {
            try
            {
                int editregion = int.Parse(Console.ReadLine());
                Console.WriteLine();

                switch (editregion)
                {
                    case 1:
                        RegionView.GetById();
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 2:
                        RegionView.Insert();
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 3:
                        RegionView.Update();
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 4:
                        RegionView.Delete();
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 5:
                        Console.Clear();
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
