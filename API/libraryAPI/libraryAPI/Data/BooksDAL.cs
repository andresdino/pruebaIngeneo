using libraryAPI.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace libraryAPI.Data
{
    public class BooksDAL : BaseDataAccess
    {
        internal List<Books> GetList()
        {
            List<Books> lstBooks = new List<Books>();
            string query = "SELECT * FROM Books";
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
                                Books book = new Books();
                                book.Id = Convert.ToInt32(reader["Id"]);
                                book.Titlle = Convert.ToString(reader["Title"]);
                                book.Description = Convert.ToString(reader["Description"]);
                                book.PageCount = Convert.ToInt32(reader["PageCount"]);
                                book.Excerpt = Convert.ToString(reader["Excerpt"]);
                                book.PublishDate= Convert.ToDateTime(reader["PublishDate"]);

                                lstBooks.Add(book);
                            }
                        }
                    }
                }
            }
            return lstBooks;
        }

        internal void Insert(Books book)
        {
            using (SqlConnection conn = GetConnection())
            {
                try
                {
                    string excerpt = Regex.Replace(book.Excerpt, @"(\D +)\s +\$([\d,] +)\.\d +\s + (.)", string.Empty);
                    string titlle = (book.Titlle == null ? "unknown" : book.Titlle);
                    if (titlle != null)
                        titlle = Regex.Replace(titlle, @"(\D +)\s +\$([\d,] +)\.\d +\s + (.)", string.Empty);
                    string description = Regex.Replace(book.Description, @"(\D +)\s +\$([\d,] +)\.\d +\s + (.)", string.Empty);
                    string query = $@"INSERT INTO Books (Id, Title, Description, PageCount, Excerpt, PublishDate) VALUES ({book.Id} ,'{titlle}' ,'{description}', {book.PageCount}, '{excerpt}', '{book.PublishDate}')";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Id", book.Id);
                    cmd.Parameters.AddWithValue("@Title", titlle);
                    cmd.Parameters.AddWithValue("@Description", description.ToString());
                    cmd.Parameters.AddWithValue("@PageCount", book.PageCount);
                    cmd.Parameters.AddWithValue("@Excerpt", excerpt.ToString());
                    cmd.Parameters.AddWithValue("@PublishDate", book.PublishDate);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    conn.Close();
                }
                catch (Exception ex) 
                {
                    var err = ex.Message + "  " + ex.StackTrace;
                }
               
            }
        }

        internal Books GetById(int id)
        {
            Books book = new Books();
            string query = $@"SELECT * FROM Books  WHERE Id = {id} ";
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
                                book.Id = Convert.ToInt32(reader["Id"]);
                                book.Titlle = Convert.ToString(reader["Title"]);
                                book.Description = Convert.ToString(reader["Description"]);
                                book.PageCount = Convert.ToInt32(reader["PageCount"]);
                                book.Excerpt = Convert.ToString(reader["Excerpt"]);
                                book.PublishDate = Convert.ToDateTime(reader["PublishDate"]);
                            }
                        }
                    }
                }
            }
            return book;
        }
    }
}
