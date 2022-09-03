using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Data_Access.Concrete
{
    public class SqlCustomerRepository : BaseRepository, ICustomerRepository
    {
        public void Add(Customer entity)
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
            command.ExecuteNonQuery();
        }

        public void Delete(int id)
        {
            using SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();
            string query = "Delete from Customers where Id=@id";
            using SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@id", id);
            command.ExecuteNonQuery();
        }
        public void Update(Customer entity)
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
            command.ExecuteNonQuery();
        }
        public Customer Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<Customer> GetAll()
        {
            throw new NotImplementedException();
        }

       
    }
}
