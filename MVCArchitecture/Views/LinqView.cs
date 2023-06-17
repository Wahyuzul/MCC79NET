using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVCArchitecture.Controllers;

namespace MVCArchitecture.Views
{
    internal class LinqView
    {
        public static void Menu()
        {
            Console.WriteLine("Tugas latihan linq");
            Console.WriteLine("1. Soal 1");
            Console.WriteLine("2. Soal 2");
            Console.Write("Pilih: ");
            LinqController.GetMenu();
        }
    }
}
