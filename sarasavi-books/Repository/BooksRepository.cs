using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using sarasavi_books.DBContext;
using sarasavi_books.IRepository;
using sarasavi_books.Models;
using System.Globalization;
using System.Linq.Expressions;

namespace sarasavi_books.Repository
{
    public class BooksRepository : IBooksRepository
    {
        private readonly BookContext _context;
        public BooksRepository(BookContext context)
        {
            _context = context;
        }

        public async Task<Book> CreateBook(Book book)
        {
            try
            {
                var res = _context.books.Add(book);
                await _context.SaveChangesAsync();
                return res.Entity;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public async Task<string> DeleteBook(int id)
        {
            var book = await _context.books.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (book == null)
            {
                return "Requested ID not available ";
            }
            _context.books.Remove(book);
            await _context.SaveChangesAsync();
            return " suceeded";


        }

        public async Task<Book?> GetBookByID(int id)
        {
            try
            {
                var res = _context.books.Where(x => x.Id == id).FirstOrDefault();

                return res;


            }
            catch (Exception)
            {

                throw;
            }

        }

        public Task<List<Book>> GetBooks()
        {
            try
            {
                var res = _context.books.ToListAsync();
                return res;

            }
            catch (Exception)
            {

                throw;
            }


        }

        public async Task<List<Book>> GetBooks(string searchString = "", string sortBY = "", bool isDesc = false)
        {
            IQueryable<Book> query = _context.books;

            var propertyInfo = typeof(Book).GetProperty(sortBY);

            if (propertyInfo != null)
            {

                var parameter = Expression.Parameter(typeof(Book), "x");
                var property = Expression.Property(parameter, propertyInfo);
                var lambda = Expression.Lambda<Func<Book, dynamic>>(property, parameter);


                query = isDesc ? query.OrderByDescending(lambda) : query.OrderBy(lambda);
            }

            var res = query.Where(x => searchString == "" || (x.Title.Contains(searchString) || x.Publication.Contains(searchString) || x.Author.Contains(searchString) || x.Description.Contains(searchString))).ToList();
            return res;
        }

        public async Task<Book> UpdateBook(Book bookRequest)
        {
            try
            {
                var res = _context.books.Update(bookRequest);
                await _context.SaveChangesAsync();
                return res.Entity;
            }
            catch (Exception)
            {

                throw;
            }

        }


    }
}
