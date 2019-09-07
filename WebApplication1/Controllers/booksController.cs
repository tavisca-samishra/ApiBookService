using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class booksController : ControllerBase
    {
        BookService bookService = new BookService();
        Response response;
        // GET: api/books
        [HttpGet]
        public ActionResult<Book> Get()
        {
            return StatusCode(200, bookService.GetBook());
        }

        // GET: api/books/5
        [HttpGet("{id}", Name = "Get")]
        public ActionResult<Response> Get(int id)
        {
            response = bookService.GetBook(id);
            return StatusCode(response.Status, response);
        }

        // POST: api/books
        [HttpPost]
        public ActionResult<Response> Post([FromBody] Book book)
        {
            response= bookService.AddBook(book);
            return StatusCode(response.Status, response);
        }

        // PUT: api/books/5
        [HttpPut("{id}")]
        public ActionResult<Response> Put(int id, [FromBody] Book book)
        {
            response= bookService.UpdateBook(id, book);
            return StatusCode(response.Status, response);
        }

        // DELETE: api/books/5
        [HttpDelete("{id}")]
        public ActionResult<Response> Delete(int id)
        {
            response= bookService.RemoveBooks(id);
            return StatusCode(response.Status, response);
        }
    }
}
