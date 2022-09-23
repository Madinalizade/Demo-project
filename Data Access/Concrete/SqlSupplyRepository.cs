using Core.Extention;
using Data_Access.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DataAccess.Concrete
{
    public class SqlSupplyRepository : BaseRepository, ISupplyRepository
    {
        public bool Add(Supply entity)
        {

            using SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();
            string query = "insert into Supplies(Name,Address,ContactName,Phone,CityId) value (@name,@address,@contactName,@phone,@cityId)";
            using SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@name", entity.Name);
            command.Parameters.AddWithValue("@address", entity.Address);
            command.Parameters.AddWithValue("@ContactName", entity.ContactName);
            command.Parameters.AddWithValue("@phone", entity.Phone);
            command.Parameters.AddWithValue("@cityId", entity.CityId);
            int rows = command.ExecuteNonQuery();
            return rows == 1;
        }

        public bool Delete(int id)
        {
            using SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();
            string query = "delete from Supplies where Id=@id";
            using SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@id",id);
            int rows = command.ExecuteNonQuery();
            return rows == 1;
        }
        public bool Update(Supply entity)
        {

            using SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();
            string query = "update Supplies set Name=@name,Address=@address,ContactName=@contactName,Phone=@phone,CityId=@cityId where Id=@id";
            using SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@name", entity.Name);
            command.Parameters.AddWithValue("@address", entity.Address);
            command.Parameters.AddWithValue("@contactName", entity.ContactName);
            command.Parameters.AddWithValue("@phone", entity.Phone);
            command.Parameters.AddWithValue("@cityId", entity.CityId);
            command.Parameters.AddWithValue("@id", entity.Id);
            int rows=command.ExecuteNonQuery();
            return rows == 1;
        }
        public Supply Get(int id)
        {
            using SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();
            string query = "select*from Suplies Where Id=@id";
            using SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@id", id);
            using SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
                return ReadSupply(reader);
            return null;
        }

        public List<Supply> GetAll()
        {
            using SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();
            string query = "Select*from Supplies Where Id=@id";
            using SqlCommand command = new SqlCommand(query, connection);
            List<Supply> list = new List<Supply>();
            using SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
                list.Add(ReadSupply(reader));
            return list;
        }

        private Supply ReadSupply(SqlDataReader reader)
        {
            return new Supply
            {
                Id = reader.Get<int>("Id"),
                Name=reader.Get<string>("Name"),
                ContactName=reader.Get<string>("ContactName"),
                 CityId=reader.Get<int>("CityId"),
                 Address=reader.Get<string>("Address"),
                 Phone=reader.Get<string>("Phone")
            };
        }
    }
}
