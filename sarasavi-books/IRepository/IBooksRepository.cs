using Microsoft.AspNetCore.Mvc;
using sarasavi_books.Models;

namespace sarasavi_books.IRepository
{
    public interface IBooksRepository
    {
        Task<Book> CreateBook(Book book);
        Task<List<Book>> GetBooks();
        Task<Book?> GetBookByID(int id);
        Task<Book> UpdateBook(Book bookRequest);
        Task<string> DeleteBook(int id);
        Task<List<Book>> GetBooks(string searchString = "", string sortBY = "", bool isDesc = false);
    }
}
