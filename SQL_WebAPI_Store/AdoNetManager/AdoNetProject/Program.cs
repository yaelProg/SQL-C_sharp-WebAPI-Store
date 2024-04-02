using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Specialized;
namespace AdoNetProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string connString;
            
            connString = "Data Source=SRV2\\PUPILS;Initial Catalog=Store_325905206;Integrated Security=True;";
            SqlConnection conn = new SqlConnection(connString);

            AdoClass.AddCategory(connString);
            //AdoClass.AddProduct(connString);
            //AdoClass.GetCategories(conn);
            //AdoClass.GetProducts(conn);
           
        }


    }
}
