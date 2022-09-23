using Core.Extention;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DataAccess.Concrete
{
    public class SqlCityRepository : BaseRepository, ICityRepository
    {
        public bool Add(City entity)
        {
            using SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();
            string query = "insert into Cities(name,countrId) value(@name,@countryid)";
            using SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@name", entity.Name);
            command.Parameters.AddWithValue("@countryId", entity.CountryId);
            int rows=command.ExecuteNonQuery();
            return rows == 1;
        }

        public bool Delete(int id)
        {
            using SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();
            string query = "delete from Cities where Id=@id";
            using SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@id", id);
            int rows=command.ExecuteNonQuery();
            return rows == 1;
        }
        public bool Update(City entity)
        {
            using SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();
            string query = "update Cities set Name=@name, CountryId=@countryId where Id=@id";
            using SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@name", entity.Name);
            command.Parameters.AddWithValue("@contryId", entity.CountryId);
            command.Parameters.AddWithValue("@id", entity.Id);
            int rows=command.ExecuteNonQuery();
            return rows == 1;
        }
        public City Get(int id)
        {
            using SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();
            string query = "Select*from Cities Where Id=@id";
            using SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@id", id);
            using SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
                return ReadCity(reader);
            return null;
        }

        public List<City> GetAll()
        {
            using SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();
            string query = "Select *from Cities";
            using SqlCommand command = new SqlCommand(query, connection);
            List<City> list = new List<City>();
            using SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
                list.Add(ReadCity(reader));
            return list;
        }
        private City ReadCity(SqlDataReader reader)
        {
            return new City
            {
                CountryId = reader.Get<int>("CountryId"),
                Name=reader.Get<string>("Name"),
                Id = reader.Get<int>("Id")
            };
        }
       
    }
}
