using MVCArchitecture.Controllers;
using MVCArchitecture.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCArchitecture.Views
{
    public class CountryView
    {
        public static void Menu()
        {
            CountryView.GetAll();
            Console.WriteLine("1. Get Country By ID");
            Console.WriteLine("2. Insert New Country");
            Console.WriteLine("3. Update Country");
            Console.WriteLine("4. Delete Country");
            Console.WriteLine("5. Exit");
            Console.Write("Masukan pilihan: ");
            CountryController.EditCountry();
        }
        public static void GetAll()
        {
            Console.WriteLine("Get All Countries");
            Console.WriteLine("--------------------------");
            List<Countries> countries = CountryController.GetAll();
            foreach (Countries country in countries)
            {
                Console.WriteLine("ID: " + country.Id + ", Name: " + country.Name + ", Region ID: " + country.RegionId);
            }
            Console.WriteLine();
        }
        public static void GetById()
        {
            Console.Write("Masukan ID country: ");
            string GETidregion = Console.ReadLine();

            CountryController.GetById(GETidregion);
        }
        public static void Insert()
        {
            Console.Write("Masukan id country: ");
            string INidcountry = Console.ReadLine();
            Console.Write("Masukan nama country: ");
            string INnamacountry = Console.ReadLine();
            Console.Write("Masukan ID region: ");
            int INidregion = Convert.ToInt32(Console.ReadLine());

            CountryController.Insert(INidcountry, INnamacountry, INidregion);
        }
        public static void Update()
        {
            Console.Write("Masukan ID country yang ingin diupdate: ");
            string UPidcountry = Console.ReadLine();
            Console.Write("Masukan nama Country baru: ");
            string UPnamacountry = Console.ReadLine();
            Console.Write("Masukan ID region baru: ");
            int UPregionid = Convert.ToInt32(Console.ReadLine());

            CountryController.Update(UPidcountry, UPnamacountry, UPregionid);
        }

        public static void Delete()
        {
            Console.Write("Masukan ID country: ");
            string DELidregion = Console.ReadLine();

            CountryController.Delete(DELidregion);
        }
    }
}
