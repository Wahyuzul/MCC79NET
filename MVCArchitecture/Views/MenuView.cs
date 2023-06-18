using MVCArchitecture.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCArchitecture.Views
{
    public class MenuView
    {
        public static void List()
        {
            while (true)
            {
                Console.WriteLine("Pilih Menu");
                Console.WriteLine("1. Region");
                Console.WriteLine("2. Country");
                Console.WriteLine("3. Location");
                Console.WriteLine("4. Department");
                Console.WriteLine("5. Employee");
                Console.WriteLine("6. Job");
                Console.WriteLine("7. History");
                Console.WriteLine("8. Linq");
                Console.WriteLine("9. Exit");
                Console.Write("Pilih menu: ");

                MenuController.SelectMenu();
            }          
        }
    }
}
