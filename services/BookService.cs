using Library.models;
using Library.repositories;

namespace Library.services
{
    public class BookService
    {
        readonly BookRepository _repository;

        public BookService(BookRepository repository)
        {
            _repository = repository;
        }

        public BindingSource getBooksData()
        {
            return _repository.getBooksData();
        }

        public List<BookResponse> getBooksId()
        {
            return _repository.getBooksId();
        }

        public void addBook(BookRequest bookRequest)
        {
            _repository.addBook(bookRequest);
        }

        public void modifyBook(BookModel book)
        {
            _repository.modifyBook(book);
        }

        public void deleteBook(BookResponse bookResponse)
        {
            _repository.deleteBook(bookResponse);
        }
    }
}
