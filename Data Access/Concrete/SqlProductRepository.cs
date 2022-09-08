using Core.Extention;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DataAccess.Concrete
{
    public class SqlProductRepository : BaseRepository,IProductRepository
    {
        public void Add(Product entity)
        {
            using SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();
            string query = "insert into Products(name,UnitInStock,UnitPrice,UnitOnOrder,CategoryId,SuppliesId)"+
                " Value (@name,@unitInStock,@unitPrice,@unitOnOrder,@categoryId,@suppliesId)";
            using SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@name", entity.Name);
            command.Parameters.AddWithValue("@unitInStock", entity.UnitInStock);
            command.Parameters.AddWithValue("@unitPrice", entity.UnitPrice);
            command.Parameters.AddWithValue("unitOnOrder", entity.UnitOnOrder);
            command.Parameters.AddWithValue("@categoryId", entity.CategoryId);
            command.Parameters.AddWithValue("@suppliesId", entity.SuppliesId);
            command.ExecuteNonQuery();
        }

        public void Delete(int id)
        {
            using SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();
            string query = "Delete from Products where Id=@id";
            using SqlCommand command = new SqlCommand(query,connection);
            command.Parameters.AddWithValue("@id", id);
            command.ExecuteNonQuery();
        }

        public Product Get(int id)
        {
            using SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();
            string query = "Select*from Product Where Id=@id";
            using SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@id", id);
            using SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
                return ReadProduct(reader);
            return null;
        }

        public List<Product> GetAll()
        {
            using SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();
            string query = "Select*from Product";
            using SqlCommand command = new SqlCommand(query, connection);
            List<Product> list = new List<Product>();
            using SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
                list.Add(ReadProduct(reader));
            return list;
        }

        public void Update(Product entity)
        {
            using SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();
            string query = "update Products set Name=@name,UnitInStock=@unitInStock,UnitPrice=@unitPrice,UnitOnOrder=@unitOnOrder,CategoryId=@categoryId,SuppliesId=@suppliesId Where Id=@id";

            using SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@name", entity.Name);
            command.Parameters.AddWithValue("@unitInStock", entity.UnitInStock);
            command.Parameters.AddWithValue("@unitPrice", entity.UnitPrice);
            command.Parameters.AddWithValue("unitOnOrder", entity.UnitOnOrder);
            command.Parameters.AddWithValue("@categoryId", entity.CategoryId);
            command.Parameters.AddWithValue("@suppliesId", entity.SuppliesId);
            command.Parameters.AddWithValue("@id", entity.Id);
            command.ExecuteNonQuery();
        }

        private Product ReadProduct(SqlDataReader reader)
        {
            return new Product
            {
                Id = reader.Get<int>("Id"),
                CategoryId = reader.Get<int>("Id"),
                Name=reader.Get<string>("Name"),
                SuppliesId=reader.Get<int>("SuppliesId"),
                UnitInStock=reader.Get<int>("UnitInStock"),
                UnitOnOrder=reader.Get<int>("UnitOnOrder"),
                UnitPrice =reader.Get<decimal>("unitPrice")
            };
        }
        
    }
}
