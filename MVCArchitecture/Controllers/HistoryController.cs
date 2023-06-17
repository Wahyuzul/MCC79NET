using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVCArchitecture.Models;

namespace MVCArchitecture.Controllers
{
    internal class HistoryController
    {
        public static List<Histories> GetAll()
        {
            var history = new List<Histories>();
            try
            {
                Program.connection = new SqlConnection(Program.connectionString);

                //Membuat instance untuk command
                SqlCommand command = new SqlCommand();
                command.Connection = Program.connection;
                command.CommandText = "SELECT * FROM tb_tr_histories";

                //membuka koneksi
                Program.connection.Open();

                using SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var h = new Histories();
                        h.startDate = reader.GetDateTime(0);
                        h.Id = reader.GetInt32(1);

                        if (!reader.IsDBNull(2))
                        {
                            h.endDate = reader.GetDateTime(2);
                        }

                        h.dptID = reader.GetInt32(3);
                        h.jobID = reader.GetString(4);

                        history.Add(h);
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
            return history;
        }
    }
}
