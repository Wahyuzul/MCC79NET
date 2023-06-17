using MVCArchitecture.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVCArchitecture.Views;

namespace MVCArchitecture.Controllers
{
    internal class CountryController
    {
        public static List<Countries> GetAll()
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

        public static void GetById(string id)
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

        public static int Insert(string id, string nama, int regionid)
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

        public static int Update(string id, string name, int regionid)
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

        public static int Delete(string id)
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

        public static void EditCountry()
        {
            try
            {
                int editcountry = int.Parse(Console.ReadLine());
                Console.WriteLine();

                switch (editcountry)
                {
                    case 1:
                        CountryView.GetById();
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 2:
                        CountryView.Insert();
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 3:
                        CountryView.Update();
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 4:
                        CountryView.Delete();
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 5:
                        Console.Clear();
                        break;
                    default:
                        Console.WriteLine("Invalid");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}
