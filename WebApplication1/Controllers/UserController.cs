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
    public class UserController : ControllerBase
    {
        BookService bookService = new BookService();

        // GET: api/User
        [HttpGet]
        public IEnumerable<Book> Get()
        {
            return bookService.GetBook();
        }

        // GET: api/User/5
        [HttpGet("{id}", Name = "Get")]
        public Response Get(int id)
        {
            return bookService.GetBook(id);
        }

        // POST: api/User
        [HttpPost]
        public Response Post([FromBody] Book value)
        {
            return bookService.AddBook(value);
        }

        // PUT: api/User/5
        [HttpPut("{id}")]
        public Response Put(int id, [FromBody] Book value)
        {
            return bookService.UpdateBook(id, value);
        }

        // DELETE: api/User/5
        [HttpDelete("{id}")]
        public Response Delete(int id)
        {
            return bookService.RemoveBooks(id);
        }
    }
}
