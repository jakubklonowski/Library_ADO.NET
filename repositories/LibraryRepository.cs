using Library.models;
using System.Data;
using System.Data.SqlClient;

namespace Library.repositories
{
    public class LibraryRepository
    {
        readonly string _connectionString;

        public LibraryRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public BindingSource getBorrowedBooks()
        {
            using SqlConnection connection = new(_connectionString);
            string queryBorrowed = "";
            SqlCommand commandBorrowed = new(queryBorrowed, connection);
            SqlDataAdapter sqlDataAdapterBorrowed = new(commandBorrowed);
            DataTable dataTableBorrowed = new();
            sqlDataAdapterBorrowed.Fill(dataTableBorrowed);
            BindingSource bindingSourceBorrowed = new()
            {
                DataSource = dataTableBorrowed
            };
            return bindingSourceBorrowed;
        }

        public List<LibraryResponse> getBorrowedBooksId()
        {
            List<LibraryResponse> ids = new();
            using SqlConnection connection = new(_connectionString);
            string queryBooksId = "SELECT id FROM library";
            SqlCommand commandBooksId = new(queryBooksId, connection);
            try
            {
                connection.Open();
                SqlDataReader booksIdReader = commandBooksId.ExecuteReader();
                while (booksIdReader.Read())
                {
                    ids.Add(new LibraryResponse()
                    {
                        Id = (int)booksIdReader[0]
                    });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return ids;
        }

        public void addBorrow(LibraryRequestJoin libraryRequestJoin)
        {

        }

        public void modifyBorrow(LibraryModelJoin libraryModelJoin)
        {

        }

        public void deleteBorrow(LibraryResponse libraryResponse)
        {

        }
    }
}
