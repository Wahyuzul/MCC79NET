using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVCArchitecture.Models;

namespace MVCArchitecture.Controllers
{
    internal class LocationController
    {
        public static List<Locations> GetAll()
        {
            var location = new List<Locations>();
            try
            {
                Program.connection = new SqlConnection(Program.connectionString);

                //Membuat instance untuk command
                SqlCommand command = new SqlCommand();
                command.Connection = Program.connection;
                command.CommandText = "SELECT * FROM tb_m_locations";

                //membuka koneksi
                Program.connection.Open();

                using SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var lc = new Locations();
                        lc.Id = reader.GetInt32(0);
                        lc.StreetAdrs = reader.GetString(1);
                        lc.Postal = reader.GetString(2);
                        lc.City = reader.GetString(3);

                        if (!reader.IsDBNull(4))
                        {
                            lc.State = reader.GetString(4);
                        }
                        else
                        {
                            lc.State = "-";
                        }

                        lc.CtrID = reader.GetString(5);

                        location.Add(lc);
                    }
                }
                else
                {
                    Console.WriteLine("Data not found!");
                }
                reader.Close();

            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            Program.connection.Close();
            return location;
        }
    }
}
