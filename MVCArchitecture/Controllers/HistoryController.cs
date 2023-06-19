using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVCArchitecture.Models;
using MVCArchitecture.Views;

namespace MVCArchitecture.Controllers
{
    internal class HistoryController
    {
      public static void Menu()
        {
            Histories history = new Histories();
            HistoryView.List(history.GetAll());
        }
    }
}
