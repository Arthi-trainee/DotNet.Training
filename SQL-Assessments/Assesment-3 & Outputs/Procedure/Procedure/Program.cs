using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Assessment6
{
    class Program
    {
        public static SqlConnection con;
        public static SqlCommand cmd;

        static SqlConnection getConnection()
        {
            try
            {
                con = new SqlConnection("Data Source=ICS-LT-D244D68Y;Initial Catalog=Assesment_3;Integrated Security=true;");
                con.Open();
                return con;
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Database connection error: " + ex.Message);
                return null;
            }
        }

        static void GetProductDetails()
        {
            try
            {
                con = getConnection();
                if (con == null)
                {
                    Console.WriteLine("Unable to establish connection to the database.");
                    return;
                }

                cmd = new SqlCommand("Update_id", con);
                cmd.CommandType = CommandType.StoredProcedure;

                Console.Write("Enter the product name: ");
                string prodName = Console.ReadLine();
                Console.Write("\nEnter the product price: ");
                int prdPrice = Convert.ToInt32(Console.ReadLine());

                SqlParameter p1 = new SqlParameter();
                p1.ParameterName = "@Prod_Name";
                p1.Value = prodName;
                p1.DbType = DbType.String;
                p1.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(p1);

                SqlParameter p2 = new SqlParameter();
                p2.ParameterName = "@Prod_price";
                p2.Value = prdPrice;
                p2.DbType = DbType.Int32;
                p2.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(p2);

                SqlDataReader dr = cmd.ExecuteReader();

             
                Console.WriteLine("Discounted price is "+prdPrice);

                while (dr.Read())
                {
                    Console.WriteLine(dr[0] + "\t" + dr[1] + "\t" + dr[2] + "\t" + dr[3]);
                }

                dr.Close(); 
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL error: " + ex.Message);
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Input format error: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An unexpected error occurred: " + ex.Message);
            }
            finally
            {
                
                if (con != null && con.State == ConnectionState.Open)
                {
                    con.Close();
                    Console.WriteLine("Connection closed.");
                }
            }
        }

        static void Main(string[] args)
        {
            GetProductDetails();
            Console.Read();
        }
    }
}