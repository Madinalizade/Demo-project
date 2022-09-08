using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Data_Access.Concrete
{
    public class SqlOrderRepository : BaseRepository, IOrderRepository
    {
        public void Add(Order entity)
        {
            using SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();
            string query = "insert into Orders(CustomerId,ProductId,OrderDate,EmployeeId) value (@customerId,@productId,@orderDate,@employee)";
            using SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@customerId", entity.CustomerId);
            command.Parameters.AddWithValue("@productId", entity.ProductId);
            command.Parameters.AddWithValue("@orderDate", entity.OrderDate);
            command.Parameters.AddWithValue("@employeeId", entity.EmployeeId);
            command.ExecuteNonQuery();
        }

        public void Delete(int id)
        {
            using SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();
            string query = "Delete from Orders where Id=@id";
            using SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@id", id);
        }
        public void Update(Order entity)
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
            command.ExecuteNonQuery();
        }
        public Order Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<Order> GetAll()
        {
            throw new NotImplementedException();
        }

       
    }
}
