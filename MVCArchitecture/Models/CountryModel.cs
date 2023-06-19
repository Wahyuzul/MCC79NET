using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCArchitecture.Models
{
    public class Countries
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int RegionId { get; set; }

        public List<Countries> GetAll()
        {
            var country = new List<Countries>();
            try
            {
                Program.connection = new SqlConnection(Program.connectionString);

                //Membuat instance untuk command
                SqlCommand command = new SqlCommand();
                command.Connection = Program.connection;
                command.CommandText = "SELECT * FROM tb_m_countries";

                //membuka koneksi
                Program.connection.Open();

                using SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var ctr = new Countries();
                        ctr.Id = reader.GetString(0);
                        ctr.Name = reader.GetString(1);
                        ctr.RegionId = reader.GetInt32(2);

                        country.Add(ctr);
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
            return country;
        }

        public void GetById(string id)
        {
            var country = new Countries();
            try
            {
                // create instance for command
                SqlCommand command = new SqlCommand();
                command.Connection = Program.connection;
                command.CommandText = "SELECT * FROM tb_m_countries WHERE id = @id";

                Program.connection.Open();

                // create parameter Id
                SqlParameter parameterName = new SqlParameter();
                parameterName.ParameterName = "@id";
                parameterName.Value = id;
                parameterName.SqlDbType = SqlDbType.VarChar;

                // add parameter
                command.Parameters.Add(parameterName);

                using SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    country.Id = reader.GetString(0);
                    country.Name = reader.GetString(1);
                    country.RegionId = reader.GetInt32(2);
                }
                else
                {
                    country = new Countries();
                }
                reader.Close();
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            Program.connection.Close();
            Console.WriteLine("ID: " + country.Id + ", Name: " + country.Name + ", Region ID: " + country.RegionId);
        }

        public int Insert(string id, string nama, int regionid)
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
                command.CommandText = "insert into tb_m_countries (id, name, region_id) values ((@country_id), (@country_name), (@region_id))";
                command.Transaction = transaction;

                //Membuat parameter

                SqlParameter pCID = new SqlParameter();
                pCID.ParameterName = "@country_id";
                pCID.Value = id;
                pCID.SqlDbType = SqlDbType.VarChar;

                SqlParameter pName = new SqlParameter();
                pName.ParameterName = "@country_name";
                pName.Value = nama;
                pName.SqlDbType = SqlDbType.VarChar;

                SqlParameter pRID = new SqlParameter();
                pRID.ParameterName = "@region_id";
                pRID.Value = regionid;
                pRID.SqlDbType = SqlDbType.Int;

                //Menambahkan parameter ke command
                command.Parameters.Add(pCID);
                command.Parameters.Add(pName);
                command.Parameters.Add(pRID);

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

        public int Update(string id, string name, int regionid)
        {
            int result = 0;
            Program.connection.Open();

            SqlTransaction transaction = Program.connection.BeginTransaction();
            try
            {
                // create instance for command
                SqlCommand command = new SqlCommand();
                command.Connection = Program.connection;
                command.CommandText = "UPDATE tb_m_countries SET name = @country_name , region_id = @region_id WHERE id = @country_id";
                command.Transaction = transaction;

                // create parameter Id
                SqlParameter pCID = new SqlParameter();
                pCID.ParameterName = "@country_id";
                pCID.Value = id;
                pCID.SqlDbType = SqlDbType.VarChar;

                SqlParameter pName = new SqlParameter();
                pName.ParameterName = "@country_name";
                pName.Value = name;
                pName.SqlDbType = SqlDbType.VarChar;

                SqlParameter pRID = new SqlParameter();
                pRID.ParameterName = "@region_id";
                pRID.Value = regionid;
                pRID.SqlDbType = SqlDbType.Int;

                //Menambahkan parameter ke command
                command.Parameters.Add(pCID);
                command.Parameters.Add(pName);
                command.Parameters.Add(pRID);

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

        public int Delete(string id)
        {
            int result = 0;
            Program.connection.Open();

            SqlTransaction transaction = Program.connection.BeginTransaction();
            try
            {
                // create instance for command
                SqlCommand command = new SqlCommand();
                command.Connection = Program.connection;
                command.CommandText = "DELETE from tb_m_countries WHERE id = @id";
                command.Transaction = transaction;


                // create parameter Id
                SqlParameter parameterCId = new SqlParameter();
                parameterCId.ParameterName = "@id";
                parameterCId.Value = id;
                parameterCId.SqlDbType = SqlDbType.VarChar;

                // add parameter
                command.Parameters.Add(parameterCId);

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
