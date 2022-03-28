using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P4_Lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            string connection = "Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = Northwind; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False";

            SqlConnection con = new SqlConnection(connection);

            string zapytanie = "INSERT INTO  dbo.Region (RegionID,RegionDescription) VALUES(@RegionID, @RegionDescription)";
            SqlCommand cmd = new SqlCommand(zapytanie, con);


            cmd.Parameters.AddWithValue("@RegionID", "6");
            cmd.Parameters.AddWithValue("@RegionDescription", "Zachód");
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                Console.WriteLine("Dodawanie udało sie");
            }
            catch (SqlException e)
            {
                Console.WriteLine("Error" + e.ToString());
            }
            finally
            {
                con.Close();
                Console.ReadKey();
            }

            SqlConnection połacz = new SqlConnection(connection);
            połacz.Open();
            string query = "SELECT * from dbo.Region";

            SqlCommand command = new SqlCommand(query, połacz);

            var result = command.ExecuteReader();



            while (result.Read())
            {
                Console.WriteLine(result.GetInt32(0) + " " + result["RegionDescription"]);
            }

            połacz.Close();


        }
    }
}