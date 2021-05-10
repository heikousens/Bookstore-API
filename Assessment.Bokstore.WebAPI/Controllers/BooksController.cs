using Assessment.Bookstore.Domain.Interfaces;
using Assessment.Bookstore.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assessment.Bokstore.WebAPI.Controllers
{
    [Route("api/books")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        public IBookService BookService { get; }

        public BooksController(IBookService bookService)
        {
            BookService = bookService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Book>> GetBooks()
        {
            var books = BookService.ShowAllBooks();
            return Ok(books);
        }

        [HttpGet("{idBook}")]
        public ActionResult GetBook([FromRoute] Guid idBook)
        {
            var book = BookService.ShowBook(idBook);

            if (book == null)
            {
                return NotFound();
            }

            return Ok(book);
        }

        [HttpPost]
        public ActionResult PostBook([FromBody] DataBook dataBook)
        {

            var registeredBook = BookService.RegisterBook(dataBook);

            return Created("GetBook", registeredBook.Book);
        }

        [HttpPut("{idBook}")]
        public ActionResult<Book> PutBook([FromRoute] Guid idBook, Book book)
        {
            if (idBook != book.Id)
            {
                return BadRequest();
            }

            BookService.UpdateBook(idBook, book);

            return Ok(book);
        }

        [HttpDelete("{idBook}")]
        public ActionResult<Book> DeleteBook([FromRoute] Guid idBook)
        {

            var book = BookService.ShowBook(idBook);

            if (book == null)
            {
                return NotFound();
            }

            BookService.DeleteBook(idBook);

            return NoContent();

        }
    }
}
