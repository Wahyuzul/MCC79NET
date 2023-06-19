using MVCArchitecture.Controllers;
using MVCArchitecture.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCArchitecture.Views
{
    internal class HistoryView
    {
        public static void List(List<Histories> histories)
        {
            //get all locations
            Console.WriteLine("Get All Histories");
            foreach (Histories history in histories)
            {
                Console.WriteLine("=======================================");
                Console.WriteLine("Employee ID: " + history.Id);
                Console.WriteLine("Start Date: " + history.startDate);
                Console.WriteLine("End Date: " + history.endDate);
                Console.WriteLine("Department ID: " + history.dptID);
                Console.WriteLine("Job ID: " + history.jobID);
                Console.WriteLine("=======================================");
                Console.WriteLine();
            }
        }
    }
}
