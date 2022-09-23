using Core.Extention;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DataAccess.Concrete
{
    public class SqlCustomerRepository : BaseRepository, ICustomerRepository
    {
        public bool Add(Customer entity)
        {
            using SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();
            string query = "insert into Customers(FirstName,LastName,Address,CityId,Phone) value(@firstName,@lastName,@adress,@cityId,@phone)";
            using SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@firstName", entity.FirstName);
            command.Parameters.AddWithValue("@lastName", entity.LastName);
            command.Parameters.AddWithValue("@address", entity.Address);
            command.Parameters.AddWithValue("cityId", entity.CityId);
            command.Parameters.AddWithValue("phone", entity.Phone);
            int rows=command.ExecuteNonQuery();
            return rows == 1;
        }

        public bool Delete(int id)
        {
            using SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();
            string query = "Delete from Customers where Id=@id";
            using SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@id", id);
            int rows=command.ExecuteNonQuery();
            return rows == 1;
        }
        public bool Update(Customer entity)
        {
            using SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();
            string query = "update Customers set FirstName=@firstName,LastName=@lastName,Address=@address,CityId=@cityId,Phone=@phone where Id=@id";
            using SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("firstName", entity.FirstName);
            command.Parameters.AddWithValue("lastName", entity.LastName);
            command.Parameters.AddWithValue("adsress", entity.Address);
            command.Parameters.AddWithValue("cityId", entity.CityId);
            command.Parameters.AddWithValue("phone", entity.Phone);
            command.Parameters.AddWithValue("@id", entity.Id);
            int rows=command.ExecuteNonQuery();
            return rows == 1;
        }
        public Customer Get(int id)
        {
            using SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();
            string query = "Select *from Customer Where Id=@id";
            using SqlCommand command= new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Id", id);
            using SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
                return ReadCustomer(reader);
            return null;
        }

        public List<Customer> GetAll()
        {
            using SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();
            string query = "Select *from Customers ";
            using SqlCommand command = new SqlCommand(query, connection);
            List<Customer> list = new List<Customer>();
            using SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
                list.Add(ReadCustomer(reader));
            return list;
        }
        private Customer ReadCustomer(SqlDataReader reader)
        {
            return new Customer
            {
                Id = reader.Get<int>("Id"),
                CityId=reader.Get<int>("CityId"),
                FirstName=reader.Get<string>("FirstName"),
                LastName=reader.Get<string>("LastName"),
                Address=reader.Get<string>("Address"),
                Phone=reader.Get<string>("Phone")
            };
        }
       
    }
}
