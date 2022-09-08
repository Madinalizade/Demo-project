using Core.Extention;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DataAccess.Concrete
{
    public class SqlEmployeeRepository : BaseRepository, IEmployeeRepository
    {
        public void Add(Employee entity)
        {
            using SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();
            string query = "insert into Employees(FirstName,LastName,PhoneNumper) value (@firstName,@lastName,@phoneNumber)";
            using SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@firstName", entity.FirstName);
            command.Parameters.AddWithValue("@lastName", entity.LastName);
            command.Parameters.AddWithValue("@phoneNumber", entity.PhoneNumber);
            command.ExecuteNonQuery();
        }

        public void Delete(int id)
        {
            using SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();
            string query = "Delete from Employees where Id=@id";
            using SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@id", id);
            command.ExecuteNonQuery();
        }
        public void Update(Employee entity)
        {
            using SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();
            string query = "update Employees set FirstName=@firstName,LastName=@lastName,PhoneNumber=@phoneNumber where Id=@id";
            using SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@firstName", entity.FirstName);
            command.Parameters.AddWithValue("@lastName", entity.LastName);
            command.Parameters.AddWithValue("@phoneNumber", entity.PhoneNumber);
            command.Parameters.AddWithValue("@id", entity.Id);
            command.ExecuteNonQuery();
        }
        public Employee Get(int id)
        {
            using SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();
            string query = "select * from Employees where Id=@id";
            using SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@id", id);
            using SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
                return ReadEmployee(reader);
            return null;
        }

        public List<Employee> GetAll()
        {
            using SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();
            string query = "Select*from Employees ";
            using SqlCommand command = new SqlCommand(query, connection);
            using SqlDataReader reader = command.ExecuteReader();
            List<Employee> list = new List<Employee>();
            while (reader.Read()) 
               list.Add(ReadEmployee(reader));
            return list;
           
        }
        private Employee ReadEmployee(SqlDataReader reader)
        {
            return new Employee
            {
                FirstName = reader.Get<string>("FirstName"),
                LastName=reader.Get<string>("LastName"),
                 PhoneNumber=reader.Get<string>("PhoneNumber"),
                 Id=reader.Get<int>("Id")
            };
        }
        
    }
}
