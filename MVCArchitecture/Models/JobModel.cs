using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCArchitecture.Models
{
    internal class Jobs
    {
        public string Id { get; set; }
        public string title { get; set; }
        public int minSalary { get; set; }
        public int maxSalary { get; set; }
        public static List<Jobs> GetAll()
        {
            var job = new List<Jobs>();
            try
            {
                Program.connection = new SqlConnection(Program.connectionString);

                //Membuat instance untuk command
                SqlCommand command = new SqlCommand();
                command.Connection = Program.connection;
                command.CommandText = "SELECT * FROM tb_m_jobs";

                //membuka koneksi
                Program.connection.Open();

                using SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var j = new Jobs();
                        j.Id = reader.GetString(0);
                        j.title = reader.GetString(1);
                        j.minSalary = reader.GetInt32(2);
                        j.maxSalary = reader.GetInt32(3);

                        job.Add(j);
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
            return job;
        }
    }
}
