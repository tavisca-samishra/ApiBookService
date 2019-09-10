using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Http;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class booksController : Controller
    {
        BookService bookService = new BookService();
        HttpRequestMessage request = new HttpRequestMessage();
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
        [ValidateModel]
        public HttpResponseMessage Post(Book book)
        {
            if (ModelState.IsValid)
            {
                response = bookService.AddBook(book);
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            else
            {
                return request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState.ToString());
            }
        }

        // PUT: api/books/5
        [HttpPut("{id}")]
        [ValidateModel]
        public HttpResponseMessage Put(int id, [FromBody] Book book)
        {
            if (ModelState.IsValid)
            {
                response = bookService.UpdateBook(id, book);
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            else
            {
                return request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState.ToString());
            }
        }

        // DELETE: api/books/5
        [HttpDelete("{id}")]
        public ActionResult<Response> Delete(int id)
        {
            response = bookService.RemoveBooks(id);
            return StatusCode(response.Status, response);
        }
    }
}
