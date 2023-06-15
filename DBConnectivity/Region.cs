
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DBConnectivity
{
    internal class Region
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public static List<Region> GetAllRegion()
        {
            var region = new List<Region>();
            try
            {
                Program.connection = new SqlConnection(Program.connectionString);

                //Membuat instance untuk command
                SqlCommand command = new SqlCommand();
                command.Connection = Program.connection;
                command.CommandText = "SELECT * FROM tb_m_regions";

                //membuka koneksi
                Program.connection.Open();

                using SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var reg = new Region();
                        reg.Id = reader.GetInt32(0);
                        reg.Name = reader.GetString(1);

                        region.Add(reg);
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
            return region;
        }

        public static List<Region> GetRegionByID(int id)
        {
            var region = new List<Region>();
            try
            {
                // create instance for command
                SqlCommand command = new SqlCommand();
                command.Connection = Program.connection;
                command.CommandText = "SELECT * FROM tb_m_regions WHERE id = @id";

                Program.connection.Open();

                // create parameter Id
                SqlParameter parameterName = new SqlParameter();
                parameterName.ParameterName = "@id";
                parameterName.Value = id;
                parameterName.SqlDbType = SqlDbType.Int;

                // add parameter
                command.Parameters.Add(parameterName);

                using SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var reg = new Region();
                        reg.Id = reader.GetInt32(0);
                        reg.Name = reader.GetString(1);

                        region.Add(reg);
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
            return region;
        }

        public static int InsertRegion(string nama)
        {
            int result = 0;
            Program.connection = new SqlConnection(Program.connectionString);

            Program.connection.Open();

            SqlTransaction transaction = Program.connection.BeginTransaction();
            try
            {
                //Membuat instance untuk command
                SqlCommand command = new SqlCommand();
                command.Connection = Program.connection;
                command.CommandText = "insert into tb_m_regions (name) values (@region_name)";
                command.Transaction = transaction;

                //Membuat parameter
                SqlParameter pName = new SqlParameter();
                pName.ParameterName = "@region_name";
                pName.Value = nama;
                pName.SqlDbType = SqlDbType.VarChar;

                //Menambahkan parameter ke command
                command.Parameters.Add(pName);

                //Menjalankan command 
                result = command.ExecuteNonQuery();
                transaction.Commit();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                try
                {
                    transaction.Rollback();
                }
                catch (Exception rollback)
                {
                    Console.WriteLine(rollback.Message);
                }
            }
            Program.connection.Close();
            return result;
        }

        public static int UpdateRegion(int id, string name)
        {
            int result = 0;
            Program.connection.Open();

            SqlTransaction transaction = Program.connection.BeginTransaction();
            try
            {
                // create instance for command
                SqlCommand command = new SqlCommand();
                command.Connection = Program.connection;
                command.CommandText = "UPDATE tb_m_regions SET name = @name WHERE id = @id";
                command.Transaction = transaction;


                // create parameter Id
                SqlParameter parameterName = new SqlParameter();
                parameterName.ParameterName = "@id";
                parameterName.Value = id;
                parameterName.SqlDbType = SqlDbType.Int;

                // create parameter Name
                SqlParameter parameterId = new SqlParameter();
                parameterId.ParameterName = "@name";
                parameterId.Value = name;
                parameterId.SqlDbType = SqlDbType.VarChar;

                // add parameter
                command.Parameters.Add(parameterName);
                command.Parameters.Add(parameterId);

                // run command
                result = command.ExecuteNonQuery();
                transaction.Commit();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                try
                {
                    transaction.Rollback();
                }
                catch (Exception rollback)
                {
                    Console.WriteLine(rollback.Message);
                }

            }
            Program.connection.Close();
            return result;
        }

        public static int DeleteRegion(int id)
        {
            int result = 0;
            Program.connection.Open();

            SqlTransaction transaction = Program.connection.BeginTransaction();
            try
            {
                // create instance for command
                SqlCommand command = new SqlCommand();
                command.Connection = Program.connection;
                command.CommandText = "DELETE from tb_m_regions WHERE id = @id";
                command.Transaction = transaction;


                // create parameter Id
                SqlParameter parameterId = new SqlParameter();
                parameterId.ParameterName = "@id";
                parameterId.Value = id;
                parameterId.SqlDbType = SqlDbType.Int;

                // add parameter
                command.Parameters.Add(parameterId);

                // run command
                result = command.ExecuteNonQuery();
                transaction.Commit();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                try
                {
                    transaction.Rollback();
                }
                catch (Exception rollback)
                {
                    Console.WriteLine(rollback.Message);
                }

            }
            Program.connection.Close();
            return result;
        }
    }
}
