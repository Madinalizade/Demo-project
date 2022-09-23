using Core.Extention;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DataAccess.Concrete
{
    public class SqlCategoryRepository : BaseRepository, ICategoryRepository
    {
        public bool Add(Category entity)
        {
            using SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();
            string query = "insert into Category(Name) values(@name)";
            using SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@name", entity.Name);
            int rows = command.ExecuteNonQuery();
            return rows == 1;
        }

        public bool Delete(int id)
        {

            using SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();
            string query = "delete from Category where Id=@id";
            using SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@id", id);
            int rows=command.ExecuteNonQuery();
            return rows == 1;
        }
        public bool Update(Category entity)
        {
            using SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();
            string query = "update Category set Name=@name where Id=@id ";
            using SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@name", entity.Name);
            command.Parameters.AddWithValue("@id", entity.Id);
            int rows=command.ExecuteNonQuery();
            return rows == 1;
        }
        public Category Get(int id)
        {
            using SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();
            string query = "select * from Category where Id=@id";
            using SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@id", id);
            using SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
                return ReadCategory(reader);
            return null;
        }

        public List<Category> GetAll()
        {
            using SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();
            string query = "select  * from Category";
            using SqlCommand command = new SqlCommand(query, connection);
            using SqlDataReader reader = command.ExecuteReader();
            List<Category> categories = new List<Category>();
            while (reader.Read())
                categories.Add(ReadCategory(reader));
            return categories;
        }

        private Category ReadCategory (SqlDataReader reader)
        {

            return new Category
            {
                Id=reader.Get<int>("Id"),
                Name=reader.Get<string>("Name")
            };
        }
       
    }
}
