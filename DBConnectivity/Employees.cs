﻿
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBConnectivity
{
    internal class Employees
    {
        public int Id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public DateTime hiredate { get; set; }
        public int salary { get; set; }
        public decimal comission { get; set; }
        public int ManagerID { get; set; }
        public string JobID { get; set; }
        public int DptID { get; set; }


        public static List<Employees> GetAllEmployee()
        {
            var employee = new List<Employees>();
            try
            {
                Program.connection = new SqlConnection(Program.connectionString);

                //Membuat instance untuk command
                SqlCommand command = new SqlCommand();
                command.Connection = Program.connection;
                command.CommandText = "SELECT * FROM tb_m_employees";

                //membuka koneksi
                Program.connection.Open();

                using SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var emp = new Employees();
                        emp.Id = reader.GetInt32(0);
                        emp.firstName = reader.GetString(1);
                        emp.lastName = reader.GetString(2);
                        emp.email = reader.GetString(3);
                        emp.phone = reader.GetString(4);
                        emp.hiredate = reader.GetDateTime(5);
                        emp.salary = reader.GetInt32(6);
                        emp.comission = reader.GetDecimal(7);

                        if (!reader.IsDBNull(8))
                        {
                            emp.ManagerID = reader.GetInt32(8);
                        }
                        else
                        {
                            emp.ManagerID = 0;
                        }

                        emp.JobID = reader.GetString(9);
                        emp.DptID = reader.GetInt32(10);

                        employee.Add(emp);
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
            return employee;
        }
    }
}
