using ProductProject.DataAccessLayer.Abstract;
using ProductProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace ProductProject.DataAccessLayer.Concrete.AdoNet
{
    public class AdoProductDal : IProductDal
    {
        public void Add(Product entity)
        {
            using (SqlCommand command = new SqlCommand("INSERT INTO Products (ProductName, UnitPrice) VALUES (@ProductName, @UnitPrice)"))
            {
                command.Parameters.AddWithValue("ProductName", entity.ProductName);
                command.Parameters.AddWithValue("UnitPrice", entity.UnitPrice);
                DBMS.ExecuteNonQuery(command);
            }
        }

        public void Delete(Product entity)
        {
            using (SqlCommand command = new SqlCommand("DELETE FROM Products WHERE ProductId = @ProductId"))
            {
                command.Parameters.AddWithValue("ProductId", entity.ProductId);
                DBMS.ExecuteNonQuery(command);
            }
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            var productList = new List<Product>();
            SqlConnection connection = new SqlConnection(DBMS.Connection);
            SqlCommand command = new SqlCommand("SELECT * FROM Products", connection);
            command.Connection.Open();
            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                var product = new Product();
                product.ProductId = Convert.ToInt32(reader[0]);
                product.UnitPrice = Convert.ToDecimal(reader[2].ToString());
                product.ProductName = reader[1].ToString();
                productList.Add(product);
            }

            var list = productList.Where(filter.Compile()).ToList();
            command.Connection.Close();
            return list[0];
        }


        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            var productList = new List<Product>();
            SqlConnection connection = new SqlConnection(DBMS.Connection);
            SqlCommand command = new SqlCommand("SELECT * FROM Products", connection);
            command.Connection.Open();
            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                var product = new Product();
                product.ProductId = Convert.ToInt32(reader[0]);
                product.ProductName = reader[1].ToString();
                product.UnitPrice = Convert.ToDecimal(reader[2].ToString());
                productList.Add(product);
            }
            command.Connection.Close();
            return filter == null ? productList : productList.Where(filter.Compile()).ToList();
        }


        public void Update(Product entity)
        {
            using (SqlCommand command = new SqlCommand("UPDATE Products SET ProductName = @ProductName, UnitPrice = @UnitPrice where ProductId = @ProductId"))
            {
                command.Parameters.AddWithValue("ProductId", entity.ProductId);
                command.Parameters.AddWithValue("UnitPrice", entity.UnitPrice);
                command.Parameters.AddWithValue("ProductName", entity.ProductName);
                DBMS.ExecuteNonQuery(command);
            }
        }
    }
}
