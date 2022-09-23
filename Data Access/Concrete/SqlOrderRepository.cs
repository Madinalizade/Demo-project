using Core.Extention;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DataAccess.Concrete
{
    public class SqlOrderRepository : BaseRepository, IOrderRepository
    {
        public bool Add(Order entity)
        {
            using SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();
            string query = "insert into Orders(CustomerId,ProductId,OrderDate,EmployeeId) value (@customerId,@productId,@orderDate,@employee)";
            using SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@customerId", entity.CustomerId);
            command.Parameters.AddWithValue("@productId", entity.ProductId);
            command.Parameters.AddWithValue("@orderDate", entity.OrderDate);
            command.Parameters.AddWithValue("@employeeId", entity.EmployeeId);
            int rows=command.ExecuteNonQuery();
            return rows == 1;
        }

        public bool Delete(int id)
        {
            using SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();
            string query = "Delete from Orders where Id=@id";
            using SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@id", id);
            int rows = command.ExecuteNonQuery();
            return rows == 1;
        }
        public bool Update(Order entity)
        {

            using SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();
            string query = "update Orders set CustomerId=@customerId,ProductId=@productId,OrderDate=@orderDate,EmployeeId=@employeeId where Id=@id";
            using SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@customerId", entity.CustomerId);
            command.Parameters.AddWithValue("@productId", entity.ProductId);
            command.Parameters.AddWithValue("@orderDate", entity.OrderDate);
            command.Parameters.AddWithValue("@employeeId", entity.EmployeeId);
            command.Parameters.AddWithValue("@id", entity.Id);
            int rows=command.ExecuteNonQuery();
            return rows == 1;
        }
        public Order Get(int id)
        {
            using SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();
            string query = "select*from Orders Where Id=@id";
            using SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@id", id);
            using SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
                return ReadOrder(reader);
            return null;
        }

        public List<Order> GetAll()
        {
            using SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();
            string query = "select*from Orders ";
            using SqlCommand command = new SqlCommand(query, connection);
            using SqlDataReader reader = command.ExecuteReader();
            List<Order> list = new List<Order>();
            while (reader.Read())
                list.Add(ReadOrder(reader));
            return list;
        }

       private Order ReadOrder(SqlDataReader reader)
        {
            return new Order
            {
                Id=reader.Get<int>("Id"),
                CustomerId=reader.Get<int>("CustomerId"),
                EmployeeId=reader.Get<int>("EmployeeId"),
                ProductId=reader.Get<int>("ProductId"),
                OrderDate= reader.Get<DateTime>("OrderDate")
            };
        }
    }
}
