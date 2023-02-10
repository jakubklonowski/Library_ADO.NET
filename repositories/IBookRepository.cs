using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.models;

namespace Library.repositories
{
    internal interface IBookRepository
    {
        const string connectionString = "Data Source=DESKTOP-JH1VST5\\SQLEXPRESS;Initial Catalog=Library;User ID=sa;Password=papaja";

        public static BindingSource getBooksData()
        {
            using (SqlConnection connection = new(connectionString))
            {
                string queryBooks = "SELECT ID, Name, Author FROM Book";
                SqlCommand commandGetBooks = new(queryBooks, connection);
                SqlDataAdapter sqlDataAdapterBooks = new(commandGetBooks);
                DataTable dataTableBooks = new();
                sqlDataAdapterBooks.Fill(dataTableBooks);
                BindingSource bindingSourceBooks = new();
                bindingSourceBooks.DataSource = dataTableBooks;
                return bindingSourceBooks;
            }
        }

        public static List<BookResponse> getBooksId()
        {
            List<BookResponse> ids = new();
            using (SqlConnection connection = new(connectionString))
            {
                string queryBooksId = "SELECT ID FROM Book";
                SqlCommand commandBooksId = new(queryBooksId, connection);
                try
                {
                    connection.Open();
                    SqlDataReader readerBookId = commandBooksId.ExecuteReader();
                    while (readerBookId.Read())
                    {
                        BookResponse bookResponse = new()
                        {
                            Id = readerBookId[0].ToString()
                        };
                        ids.Add(bookResponse);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return ids;
        }

        public static void addBook(BookRequest bookRequest)
        {
            using (SqlConnection connection = new(connectionString))
            {
                string queryInsert = "INSERT INTO Book (Name, Author) VALUES (@name, @author)";

                SqlCommand commandInsert = new(queryInsert, connection);
                try
                {
                    commandInsert.Parameters.Add("@name", SqlDbType.VarChar, 50).Value = bookRequest.Name;
                    commandInsert.Parameters.Add("@author", SqlDbType.VarChar, 50).Value = bookRequest.Author;
                    connection.Open();
                    commandInsert.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public static void modifyBook(BookModel book)
        {
            using (SqlConnection connection = new(connectionString))
            {
                string queryMod = "UPDATE Book SET Name=@name, Author=@author WHERE ID = @id";

                SqlCommand commandMod = new(queryMod, connection);
                try
                {
                    commandMod.Parameters.Add("@id", SqlDbType.Int).Value = book.Id;
                    commandMod.Parameters.Add("@name", SqlDbType.VarChar, 50).Value = book.Name;
                    commandMod.Parameters.Add("@author", SqlDbType.VarChar, 50).Value = book.Author;
                    connection.Open();
                    commandMod.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public static void deleteBook(BookResponse bookResponse)
        {
            using (SqlConnection connection = new(connectionString))
            {
                string queryDelete = "DELETE FROM Book WHERE ID = @id";

                SqlCommand commandDelete = new(queryDelete, connection);
                try
                {
                    commandDelete.Parameters.Add("@id", SqlDbType.Int).Value = bookResponse.Id;
                    connection.Open();
                    commandDelete.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);

                }
            }
        }
    }
}
