using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Reflection.Metadata;



namespace ConsoleApp
{
   
    class Program
    {
        public static void InsertData(SqlConnection conn2 )
        {
            string cmdText = "InsertProduct";

            SqlCommand cmd = new SqlCommand(cmdText, conn2);

            cmd.CommandType = CommandType.StoredProcedure;

            conn2.Open();

            SqlParameter p1 = new SqlParameter();
            p1.ParameterName = "@ProductName";
            Console.Write("Enter Product Name: ");
            p1.Value = Console.ReadLine();


            SqlParameter p2 = new SqlParameter();
            p2.ParameterName = "@Category";
            Console.Write("Enter Category: ");
            p2.Value = Console.ReadLine();

            SqlParameter p3 = new SqlParameter();
            p3.ParameterName = "@Price";
            Console.Write("Enter Product Price: ");
            p3.Value = decimal.Parse(Console.ReadLine());

            cmd.Parameters.Add(p1);
            cmd.Parameters.Add(p2);
            cmd.Parameters.Add(p3);

            int q1 = cmd.ExecuteNonQuery();

            Console.WriteLine($"Number of Rows Affected: {q1}");

            conn2.Close();

        }

        public static void SelectProducts(SqlConnection conn2)
        {
            string cmdText = "SelectProducts";

            SqlCommand cmd = new SqlCommand(cmdText, conn2);

            cmd.CommandType = CommandType.StoredProcedure;

            conn2.Open();

            SqlDataReader reader = cmd.ExecuteReader();

            Console.WriteLine("----- Products ------");

            while (reader.Read())
            {
                Console.WriteLine($"{reader["ProductId"]}-{reader["ProductName"]}-{reader["Category"]}-{reader["Price"]}");
            }

            conn2.Close();

            Console.WriteLine();

         

        }
        public static void UpdateProducts(SqlConnection conn2)
        {
            string cmdText = "UpdateProd";
            SqlCommand cmd = new SqlCommand(cmdText, conn2);
            cmd.CommandType = CommandType.StoredProcedure;

            conn2.Open();

            SqlParameter p1 = new SqlParameter();
            p1.ParameterName = "@ProductId";
            Console.Write("Enter Product Id: ");
            p1.Value = int.Parse(Console.ReadLine());

            SqlParameter p2 = new SqlParameter();
            p2.ParameterName = "@ProductName";
            Console.Write("Enter Product Name: ");
            p2.Value = Console.ReadLine();

            SqlParameter p3 = new SqlParameter();
            p3.ParameterName = "@Category";
            Console.Write("Enter Product Category: ");
            p3.Value = Console.ReadLine();

            SqlParameter p4 = new SqlParameter();
            p4.ParameterName = "@Price";
            Console.Write("Enter Product Price: ");
            p4.Value = decimal.Parse(Console.ReadLine());

            cmd.Parameters.Add(p1);
            cmd.Parameters.Add(p2);
            cmd.Parameters.Add(p3);
            cmd.Parameters.Add(p4);

            int q2 = cmd.ExecuteNonQuery();

            Console.WriteLine($"No.Of Rows affect: {q2}");

            conn2.Close();


        }

        public static void DeleteProduct(SqlConnection conn2)
        {
            string cmdText = "DeleteProd";
            SqlCommand cmd = new SqlCommand(cmdText,conn2);
            cmd.CommandType = CommandType.StoredProcedure;

            conn2.Open();
            SqlParameter p1 = new SqlParameter();
            p1.ParameterName = "@ProductId";
            Console.Write("Enter Product Id: ");
            p1.Value = int.Parse(Console.ReadLine());

            cmd.Parameters.Add(p1);

            int q3 = cmd.ExecuteNonQuery();

            Console.WriteLine($"No.Of rows affected: {q3}");

            conn2.Close();

        }
        public  static void Main()
        {

            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            string conn = config.GetConnectionString("DefaultConnection");

            SqlConnection conn2 = new SqlConnection(conn);

           


            while (true){
                Console.WriteLine("All Options to Choose");
                Console.WriteLine("1. Insert Product");
                Console.WriteLine("2. View All Products");
                Console.WriteLine("3. Update Product");
                Console.WriteLine("4. Delete Product");
                Console.WriteLine("5. Exit");
                Console.Write("Choose Your Option: ");
                int opt = int.Parse(Console.ReadLine());
                Console.WriteLine();

                switch (opt)
                {
                    case 1:
                        InsertData(conn2);
                        break;
                    case 2:
                        SelectProducts(conn2);
                        break;
                    case 3:
                        UpdateProducts(conn2);
                        break;
                    case 4:
                        DeleteProduct(conn2);
                        break;
                    case 5:
                        Console.WriteLine("Exiting....");
                        return;

                    default:
                        Console.WriteLine("Choose Correct Option");
                        break;

            }

            }
            










        }


    }
}