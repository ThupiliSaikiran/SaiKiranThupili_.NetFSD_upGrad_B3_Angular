using Dapper;
using Microsoft.Data.SqlClient;
using WebApplication2.Models;


namespace WebApplication2.Repositories
{
    public class ProductRepository:IProductRepository
    {
        private readonly string _connString;

        public ProductRepository(IConfiguration config)
        {
            _connString = config.GetConnectionString("DefaultConnection");
        }

        public SqlConnection GetConnection()
        {
            return new SqlConnection(_connString);
        }
        public IEnumerable<Products> GetAll()
        {
            string sql = "SELECT * FROM Products";
            var db = GetConnection();
            return db.Query<Products>(sql);
        }

        public Products GetById(int id)
        {
            string sql = "SELECT * FROM Products WHERE ProductId ="+id;
            var db = GetConnection();
            return db.QueryFirstOrDefault<Products>(sql);
        }

        public void Add(Products product)
        {
            string sql = @"INSERT INTO Products (ProductName, Category, Price) VALUES (@ProductName, @Category, @Price)";

            var db = GetConnection();

            db.Execute(sql, product);
        }

        public void Update(Products product)
        {
            string sql = @"Update Products SET ProductName=@ProductName,Price=@Price,Category=@Category WHERE ProductId = @ProductId";

            var db = GetConnection();

            db.Execute(sql, product);

        }
        public void Delete(int id)
        {
            string sql = "DELETE  FROM Products WHERE ProductId=" + id;

            var db = GetConnection();
            db.Execute(sql);
        }

    }
}
