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
        public void Add(Supply entity)
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
            command.ExecuteNonQuery();
        }

        public void Delete(int id)
        {
            using SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();
            string query = "delete from Supplies where Id=@id";
            using SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@id",id);
            command.ExecuteNonQuery();
        }
        public void Update(Supply entity)
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
            command.ExecuteNonQuery();
        }
        public Supply Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<Supply> GetAll()
        {
            throw new NotImplementedException();
        }

        
    }
}
