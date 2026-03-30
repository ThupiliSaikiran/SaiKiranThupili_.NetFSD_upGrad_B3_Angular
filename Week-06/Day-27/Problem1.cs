using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Reflection.Metadata;



namespace ConsoleApp
{
   
    class Program
    {
        public static void InsertData(SqlConnection conn2, SqlDataAdapter adapter, DataSet ds )
        {
            string cmdText = "sp_InsertProduct";

            

            adapter.InsertCommand  = new SqlCommand(cmdText, conn2);

            adapter.InsertCommand.CommandType = CommandType.StoredProcedure;

            adapter.InsertCommand.Parameters.Add("@ProductName", SqlDbType.NVarChar, 100, "ProductName");
            adapter.InsertCommand.Parameters.Add("@Category", SqlDbType.NVarChar, 50, "Category");
            SqlParameter priceParam = adapter.InsertCommand.Parameters.Add("@Price", SqlDbType.Decimal, 0, "Price");
            priceParam.Precision = 10;
            priceParam.Scale = 2;

            Console.Write("Enter Product Name: ");
            string productName = Console.ReadLine();

            Console.Write("Enter Product Category: ");
            string category = Console.ReadLine();

            Console.Write("Enter Product Price: ");
            decimal price = decimal.Parse(Console.ReadLine());


            DataRow newRow = ds.Tables["Products"].NewRow();

            newRow["ProductName"]=productName;
            newRow["Category"] = category;
            newRow["Price"] = price;

            ds.Tables["Products"].Rows.Add(newRow);

            int q1 = adapter.Update(ds, "Products");

            Console.WriteLine($"No.Of Rows Affected: {q1}");
      

        }

        public static void SelectProductById(SqlConnection conn2, SqlDataAdapter adapter, DataSet ds)
        {
            string cmdTeaxt = "sp_GetProductById";
            adapter.SelectCommand = new SqlCommand(cmdTeaxt, conn2);

            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;

            Console.Write("Enter Product Id: ");
            int productId = int.Parse(Console.ReadLine());

            adapter.SelectCommand.Parameters.AddWithValue("@ProductId", productId);

            adapter.Fill(ds, "FilteredProducts");

            if (ds.Tables["FilteredProducts"].Rows.Count > 0)
            {
                foreach(DataRow row in ds.Tables["FilteredProducts"].Rows)
                {
                    Console.WriteLine($"{row["ProductId"]}-{row["ProductName"]}-{row["Category"]}-{row["Price"]}");
                }
            }
            else
            {
                Console.WriteLine("No product found.");
            }

            Console.WriteLine();

           

        }

        public static void SelectProducts(SqlConnection conn2, SqlDataAdapter adapter, DataSet ds)
        {
            string cmdText = "sp_GetAllProducts";

            adapter.SelectCommand = new SqlCommand(cmdText, conn2);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;

            ds.Tables["Products"]?.Clear();
            adapter.Fill(ds, "Products");
            Console.WriteLine("===== Products =====");
            foreach(DataRow row in ds.Tables["Products"].Rows)
            {
                Console.WriteLine($"{row["ProductId"]}-{row["ProductName"]}-{row["Category"]}-{row["Price"]}");
            }

            

            Console.WriteLine();

         

        }
        public static void UpdateProducts(SqlConnection conn2, SqlDataAdapter adapter, DataSet ds)
        {
            string cmdText = "sp_UpdateProduct";


            adapter.UpdateCommand = new SqlCommand(cmdText, conn2);
            adapter.UpdateCommand.CommandType = CommandType.StoredProcedure;

            adapter.UpdateCommand.Parameters.Add("@ProductId", SqlDbType.Int, 0, "ProductId");
            adapter.UpdateCommand.Parameters.Add("@ProductName", SqlDbType.VarChar, 100, "ProductName");
            adapter.UpdateCommand.Parameters.Add("@Category", SqlDbType.VarChar, 50, "Category");
            SqlParameter priceParam =  adapter.UpdateCommand.Parameters.Add("@Price", SqlDbType.Decimal, 0, "ProductId");
            priceParam.Precision = 10;
            priceParam.Scale = 2;

            Console.Write("Enter Product Id: ");
            int id = int.Parse(Console.ReadLine());

            DataRow[] rows = ds.Tables["Products"].Select($"ProductId={id}");

            DataRow row = rows[0];

            Console.Write("Enter Product Name: ");
            row["ProductName"] = Console.ReadLine();

            Console.Write("Enter Product Category: ");
            row["Category"] = Console.ReadLine();

            Console.Write("Enter Product Price: ");
            row["Price"] = decimal.Parse(Console.ReadLine());

            int q2 = adapter.Update(ds, "Products");

          
            Console.WriteLine($"No.Of Rows affect: {q2}");

            Console.WriteLine();




        }

        public static void DeleteProduct(SqlConnection conn2, SqlDataAdapter adapter, DataSet ds)
        {
            string cmdText = "sp_DeleteProduct";

            adapter.DeleteCommand = new SqlCommand(cmdText, conn2);
            adapter.DeleteCommand.CommandType = CommandType.StoredProcedure;

            Console.Write("Enter Product Id: ");
            int productId = int.Parse(Console.ReadLine());

            adapter.DeleteCommand.Parameters.Add("@ProductId",SqlDbType.Int,0, "ProductId" );

          

            DataRow[] rows = ds.Tables["Products"].Select($"ProductId = {productId}");

            if (rows.Length == 0)
            {
                Console.WriteLine("Product not found.");
                return;
            }

            
            rows[0].Delete();

            int q3 = adapter.Update(ds, "Products");


            Console.WriteLine($"No.Of rows affected: {q3}");

            Console.WriteLine();

        }
        public  static void Main()
        {

            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            string conn = config.GetConnectionString("DefaultConnection");

            SqlConnection conn2 = new SqlConnection(conn);

            SqlDataAdapter adapter = new SqlDataAdapter();

            adapter.SelectCommand = new SqlCommand("SELECT * FROM Products;", conn2);

            DataSet ds = new DataSet();

            adapter.Fill(ds, "Products");




            while (true){
                Console.WriteLine("All Options to Choose");
                Console.WriteLine("1. Insert Product");
                Console.WriteLine("2. Get Product By Id");
                Console.WriteLine("3. View All Products");
                Console.WriteLine("4. Update Product");
                Console.WriteLine("5. Delete Product");
                Console.WriteLine("6. Exit");
                Console.Write("Choose Your Option: ");
                int opt = int.Parse(Console.ReadLine());
                Console.WriteLine();

                switch (opt)
                {
                    case 1:
                        InsertData(conn2,adapter,ds);
                        break;
                    case 2:
                        SelectProductById(conn2,adapter, ds);
                        break;
                    case 3:
                        SelectProducts(conn2, adapter, ds);
                        break;
                    case 4:
                        UpdateProducts(conn2, adapter, ds);
                        break;
                    case 5:
                        DeleteProduct(conn2, adapter, ds);
                        break;
                    case 6:
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