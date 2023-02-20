using Library.models;
using Library.repositories;

namespace Library.services
{
    public class LibraryService
    {
        readonly LibraryRepository _repository;

        public LibraryService(LibraryRepository repository)
        {
            _repository = repository;
        }

        public BindingSource getLibraryData()
        {
            return _repository.getBorrowedBooks();
        }

        public List<LibraryResponse> getBorrowedBookId()
        {
            return _repository.getBorrowedBooksId();
        }

        public void addBorrow(LibraryRequestJoin libraryRequestJoin)
        {
            _repository.addBorrow(libraryRequestJoin);
        }

        public void modifyBorrow(LibraryModelJoin libraryModelJoin)
        {
            _repository.modifyBorrow(libraryModelJoin);
        }

        public void deleteBorrow(LibraryResponse libraryResponse)
        {
            _repository.deleteBorrow(libraryResponse);
        }
    }
}
