using libraryAPI.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace libraryAPI.Data
{
    public class AuthorsDAL : BaseDataAccess
    {
        public AuthorsDAL() 
        {
        }

        public BaseDataAccess baseData = new BaseDataAccess();

        internal void Insert(Authors author)
        {
            using (SqlConnection conn = GetConnection())
            {
                string sql = "INSERT INTO Authors (Id, IdBook, FristName, LastName) VALUES (@Id, @IdBook, @FristName, @LastName)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Id", author.Id );
                cmd.Parameters.AddWithValue("@IdBook", author.IdBook);
                cmd.Parameters.AddWithValue("@FristName", author.IdBook);
                cmd.Parameters.AddWithValue("@LastName", author.LastName);

                int rowsAffected = cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

        internal List<Authors> GetList()
        {
            List<Authors> lstAuthors = new List<Authors>();
            string query = "SELECT * FROM Authors";
            using (SqlConnection sqlConnection = new SqlConnection(GetConnectionString()))
            {
                sqlConnection.Open();
                if (sqlConnection.State == System.Data.ConnectionState.Open)
                {
                    using (SqlCommand cmd = sqlConnection.CreateCommand())
                    {
                        cmd.CommandText = query;
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Authors author = new Authors();
                                author.Id = Convert.ToInt32(reader["Id"]);
                                author.IdBook = Convert.ToInt32(reader["IdBook"]);
                                author.FristName = Convert.ToString(reader["FristName"]);
                                author.LastName = Convert.ToString(reader["LastName"]);
                                lstAuthors.Add(author);
                            }
                        }
                    }
                }
            }
             return lstAuthors; 
        }

        internal Authors GetById(int id)
        {
            Authors author = new Authors();
            string query = $@"SELECT * FROM Authors  WHERE Id = {id} ";
            using (SqlConnection sqlConnection = new SqlConnection(GetConnectionString()))
            {
                sqlConnection.Open();
                if (sqlConnection.State == System.Data.ConnectionState.Open)
                {
                    using (SqlCommand cmd = sqlConnection.CreateCommand())
                    {
                        cmd.CommandText = query;
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                author.Id = Convert.ToInt32(reader["Id"]);
                                author.IdBook = Convert.ToInt32(reader["IdBook"]);
                                author.FristName = Convert.ToString(reader["FristName"]);
                                author.LastName = Convert.ToString(reader["LastName"]);
                            }
                        }
                    }
                }
            }
            return author;
        }
    }
}
