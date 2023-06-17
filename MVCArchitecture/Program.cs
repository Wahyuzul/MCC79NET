using MVCArchitecture.Views;
using System.Data;
using System.Data.SqlClient;
namespace MVCArchitecture;

public class Program
{
    //Connection Global
    public static string connectionString = "Data Source=DESKTOP-K75VUCD;Database=db_hr;Integrated Security=True;Connect Timeout=30;";

    public static SqlConnection connection;
    public static void Main(string[] args)
    {   //database connectivity
        connection = new SqlConnection(connectionString);

        MenuView.List();
    }
}