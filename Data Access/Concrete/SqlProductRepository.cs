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
            throw new NotImplementedException();
        }

        public List<Product> GetAll()
        {
            throw new NotImplementedException();
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
    }
}
