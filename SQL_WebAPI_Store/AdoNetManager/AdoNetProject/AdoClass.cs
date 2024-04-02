using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoNetProject
{
    internal class AdoClass
    {

        static public int AddCategory(string connstring)
        {
            string newCategoryName;
            Console.WriteLine("Enter category name");
            newCategoryName = Console.ReadLine();

            Int32 newCategoryID = 0;
            string sql =
                "INSERT INTO Category_tbl (CATEGORY_NAME) VALUES (@Name);"
                + "SELECT CAST(scope_identity() AS int)";
            using (SqlConnection conn = new SqlConnection(connstring))
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add("@Name", SqlDbType.NVarChar);
                cmd.Parameters["@Name"].Value = newCategoryName;

                try
                {
                    conn.Open();
                    newCategoryID = (Int32)cmd.ExecuteScalar();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return (int)newCategoryID;

        }

        static public int AddProduct(string connstring)
        {
            string newProductName, newDescription, newImage_url;
            int newPrice, newCategoryId;
            Console.WriteLine("Enter product name");
            newProductName = Console.ReadLine();
            Console.WriteLine("Enter product price");
            newPrice = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter category id");
            newCategoryId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter product description");
            newDescription = Console.ReadLine();
            Console.WriteLine("Enter product image url");
            newImage_url = Console.ReadLine();

            Int32 newProductID = 0;
            string sql =
                "INSERT INTO Product_tbl (PRODUCT_NAME, PRICE, CATEGORY_ID, DESCRIPTION, IMAGE_URL) VALUES (@Name, @Price, @CategoryId, @description, @image_url);"
                + "SELECT CAST(scope_identity() AS int)";
            using (SqlConnection conn = new SqlConnection(connstring))
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add("@Name", SqlDbType.NVarChar);
                cmd.Parameters["@Name"].Value = newProductName;
                cmd.Parameters.Add("@Price", SqlDbType.NVarChar);
                cmd.Parameters["@Price"].Value = newPrice;
                cmd.Parameters.Add("@CategoryId", SqlDbType.NVarChar);
                cmd.Parameters["@CategoryId"].Value = newCategoryId;
                cmd.Parameters.Add("@description", SqlDbType.NVarChar);
                cmd.Parameters["@description"].Value = newDescription;
                cmd.Parameters.Add("@image_url", SqlDbType.NVarChar);
                cmd.Parameters["@image_url"].Value = newImage_url;

                try
                {
                    conn.Open();
                    newProductID = (Int32)cmd.ExecuteScalar();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return (int)newProductID;

        }

        static public void GetCategories(SqlConnection connection)
        {
            using (connection)
            {
                SqlCommand command = new SqlCommand("SELECT * From Category_tbl;", connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    Console.WriteLine("-Categories-");
                    Console.WriteLine("id:\t name:\t");
                    while (reader.Read())
                    {
                        Console.WriteLine("{0}\t {1}", reader.GetInt32(0), reader.GetString(1));
                    }
                }
                else
                {
                    Console.WriteLine("No rows found");
                }
                reader.Close();
            }
        }

        static public void GetProducts(SqlConnection connection)
        {
            using (connection)
            {
                SqlCommand command = new SqlCommand("SELECT * From Product_tbl;", connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    Console.WriteLine("-Products-");
                    while (reader.Read())
                    {
                        Console.WriteLine("id: {0} name:{1} price:{2} category:{3} description:{4} image_url:{5}", reader[0], reader[1], reader[2], reader[3], reader[4], reader[5]);
                    }
                }
                else
                {
                    Console.WriteLine("No rows found");
                }
                reader.Close();
            }
        }
    }
}


   

