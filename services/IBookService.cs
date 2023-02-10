using Library.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.services
{
    internal interface IBookService
    {
        public static BindingSource getBooksData()
        {
            return repositories.IBookRepository.getBooksData();
        }

        public static List<BookResponse> getBooksId()
        {
            return repositories.IBookRepository.getBooksId();
        }

        public static void addBook(BookRequest bookRequest)
        {
            repositories.IBookRepository.addBook(bookRequest);
        }

        public static void modifyBook(BookModel book)
        {
            repositories.IBookRepository.modifyBook(book);
        }

        public static void deleteBook(BookResponse bookResponse)
        {
            repositories.IBookRepository.deleteBook(bookResponse);
        }
    }
}
