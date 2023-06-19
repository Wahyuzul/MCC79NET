using MVCArchitecture.Controllers;
using MVCArchitecture.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCArchitecture.Views
{
    public class RegionView
    {
        public static void Menu() 
        {
            GetAll();
            Console.WriteLine();
            Console.WriteLine("Edit Region:");
            Console.WriteLine("1. Get Region By ID");
            Console.WriteLine("2. Insert New Region");
            Console.WriteLine("3. Update Region");
            Console.WriteLine("4. Delete Region");
            Console.WriteLine("5. Exit");
            Console.Write("Masukan pilihan: ");
            RegionController.Edit();
        }

        public static void GetAll()
        {
            List<Region> regions = Region.GetAll();
            foreach (Region region in regions)
            {
                Console.WriteLine("ID: " + region.Id + ", Name: " + region.Name);
            }
        }
        public static void GetById()
        {
            Console.Write("Masukan ID region: ");
            int GETidregion = int.Parse(Console.ReadLine());

            Region.GetById(GETidregion);
        }
        public static void Insert()
        {
            Console.Write("Masukan nama region: ");
            string INnamaregion = Console.ReadLine();

            Region.Insert(INnamaregion);
        }
        public static void Update()
        {
            Console.Write("Masukan ID region yang ingin diupdate: ");
            int UPidregion = int.Parse(Console.ReadLine());
            Console.Write("Masukan nama region baru: ");
            string UPnamaregion = Console.ReadLine();

            Region.Update(UPidregion, UPnamaregion);
        }

        public static void Delete()
        {
            Console.Write("Masukan ID region: ");
            int DELidregion = int.Parse(Console.ReadLine());

            Region.Delete(DELidregion);
        }

    }
}
