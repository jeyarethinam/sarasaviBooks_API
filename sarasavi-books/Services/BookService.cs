using sarasavi_books.IRepository;
using sarasavi_books.IServices;
using sarasavi_books.Models;
using sarasavi_books.Repository;

namespace sarasavi_books.Services
{
    public class BookService : IBookService
    {
        private readonly IBooksRepository _bookRepository;
        public BookService(IBooksRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        public async Task<Book> CreateBook(Book book)
        {
            return await _bookRepository.CreateBook(book);
        }

        public async Task<string> DeleteBook(int id)
        {
           var res = await _bookRepository.DeleteBook(id);
            return res;
        }

        public async Task<Book?> GetBookByID(int id)
        {
            var res = await _bookRepository.GetBookByID(id);
            return res;
        }

        public async Task<List<Book>> GetBooks()
        {
            var res = await _bookRepository.GetBooks();
            return res;
        }

        public async Task<List<Book>> GetBooks(string searchString = "", string sortBY = "", bool isDesc = false)
        {
            var res = await _bookRepository.GetBooks(searchString, sortBY, isDesc);
            return res;
               
        }

        public async Task<Book> UpdateBook(Book bookRequest)
        {
           var res = await _bookRepository.UpdateBook(bookRequest);
            return res;
        }
    }
}
