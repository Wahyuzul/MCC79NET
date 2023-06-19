using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCArchitecture.Models
{
    internal class Departments
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int LocationID { get; set; }
        public int ManagerID { get; set; }

        public List<Departments> GetAll()
        {
            var department = new List<Departments>();
            try
            {
                Program.connection = new SqlConnection(Program.connectionString);

                //Membuat instance untuk command
                SqlCommand command = new SqlCommand();
                command.Connection = Program.connection;
                command.CommandText = "SELECT * FROM tb_m_departments";

                //membuka koneksi
                Program.connection.Open();

                using SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var dp = new Departments();
                        dp.Id = reader.GetInt32(0);
                        dp.Name = reader.GetString(1);
                        dp.LocationID = reader.GetInt32(2);

                        if (!reader.IsDBNull(3))
                        {
                            dp.ManagerID = reader.GetInt32(3);
                        }
                        else
                        {
                            dp.ManagerID = 0;
                        }

                        department.Add(dp);
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
            return department;
        }
    }
}
