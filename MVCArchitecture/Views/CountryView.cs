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
            GetAll();
            Console.WriteLine();
            Console.WriteLine("Edit Country:");
            Console.WriteLine("1. Get Country By ID");
            Console.WriteLine("2. Insert New Country");
            Console.WriteLine("3. Update Country");
            Console.WriteLine("4. Delete Country");
            Console.WriteLine("5. Exit");
            Console.Write("Masukan pilihan: ");
            CountryController.Edit();
        }

        public static void GetAll()
        {
            List<Countries> countries = Countries.GetAll();
            foreach (Countries country in countries)
            {
                Console.WriteLine("ID: " + country.Id + ", Name: " + country.Name + ", Region ID: " + country.RegionId);
            }
        }
        public static void GetById()
        {
            Console.Write("Masukan ID country: ");
            string GETidregion = Console.ReadLine();

            Countries.GetById(GETidregion);
        }
        public static void Insert()
        {
            Console.Write("Masukan id country: ");
            string INidcountry = Console.ReadLine();
            Console.Write("Masukan nama country: ");
            string INnamacountry = Console.ReadLine();
            Console.Write("Masukan ID region: ");
            int INidregion = Convert.ToInt32(Console.ReadLine());

            Countries.Insert(INidcountry, INnamacountry, INidregion);
        }
        public static void Update()
        {
            Console.Write("Masukan ID country yang ingin diupdate: ");
            string UPidcountry = Console.ReadLine();
            Console.Write("Masukan nama Country baru: ");
            string UPnamacountry = Console.ReadLine();
            Console.Write("Masukan ID region baru: ");
            int UPregionid = Convert.ToInt32(Console.ReadLine());

            Countries.Update(UPidcountry, UPnamacountry, UPregionid);
        }

        public static void Delete()
        {
            Console.Write("Masukan ID country: ");
            string DELidregion = Console.ReadLine();

            Countries.Delete(DELidregion);
        }
    }
}
