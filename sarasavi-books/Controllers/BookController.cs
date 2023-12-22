using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using sarasavi_books.DBContext;
using sarasavi_books.IServices;
using sarasavi_books.Models;

namespace sarasavi_books.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }


        [HttpPost]
        public async Task<ActionResult> CreateBook(Book bookRequest)
        {
            var res = await _bookService.CreateBook(bookRequest);
            return Ok(res);
        }

        [HttpGet]
        public async Task<ActionResult> GetBooks()
        {
            var res = await _bookService.GetBooks();
            return Ok(res);
        }



        [HttpGet("{id}")]
        public async Task<ActionResult> GetBookByID(int id)
        {
            var res = await _bookService.GetBookByID(id);
            return Ok(res);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateBook(Book bookRequest)
        {
            var res = await _bookService.UpdateBook(bookRequest);
            return Ok(res);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteBook(int id)
        {
            var res = await _bookService.DeleteBook(id);
            return Ok(res);

        }
        [HttpGet("search")]
        public async Task<ActionResult> GetBookSearch(string searchString="",string sortBY= "", bool isDesc =false)
        {
            var res = await _bookService.GetBooks(searchString, sortBY, isDesc);
            return Ok(res);
        }
       
    }
}
