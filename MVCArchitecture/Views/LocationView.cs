using MVCArchitecture.Controllers;
using MVCArchitecture.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCArchitecture.Views
{
    public class LocationView
    {
        public static void GetAll(List<Locations> locations)
        {
            //get all locations
            Console.WriteLine("Get All Locations");
            Console.WriteLine("--------------------------");
            foreach (Locations location in locations)
            {
                Console.WriteLine("ID: " + location.Id + ", Street Address: " + location.StreetAdrs + ", Postal Code: " + location.Postal + ", City: " + location.City + ", State Province: " + location.State + ", Country ID: " + location.CtrID);
            }
        }
    }
}
