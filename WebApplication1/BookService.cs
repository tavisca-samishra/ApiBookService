using System.Collections.Generic;
using WebApplication1.Models;

namespace WebApplication1
{
    public class BookService
    {
        IEnumerable<Book> books = BookData.GetBooks();
        Response response = new Response();

        public IEnumerable<Book> GetBook()
        {
            return books;
        }
        public Response GetBook(int id)
        {
            if (id < 0)
            {
                CheckGivenId();
                Forbidden();
                return response;
            }
            foreach (var item in books)
            {
                if (item.Id == id)
                {
                    response.Book = item;
                    Success();
                    response.Status = 302;
                    return response;
                }
            }
            IdNotAvailable();
            return response;
        }
        public Response AddBook(Book book)
        {
            BookData.PostBook(book);
            response.Status = 201;
            Success();
            return response;
        }
        public Response UpdateBook(int id, Book book)
        {
            if (id < 0)
            {
                CheckGivenId();
                Forbidden();
            }
            else
            {
                IdNotAvailable();
                foreach (var item in books)
                {
                    if (item.Id == id)
                    {
                        response.Message.Clear();
                    }
                }
            }
            if (response.Message.Count == 0)
            {
                Success();
                response.Status = 202;
                BookData.UpdateBooks(id, book);
            }
            return response;
        }
        public Response RemoveBooks(int id)
        {
            if (id < 0)
            {
                CheckGivenId();
                Forbidden();
            }
            else
            {
                IdNotAvailable();
                foreach (var item in books)
                {
                    if (item.Id == id)
                    {
                        response.Message.Clear();
                    }
                }
            }
            if (response.Message.Count == 0)
            {
                Success();
                response.Status = 202;
                BookData.RemoveBookById(id);
            }
            return response;
        }

        private void IdNotAvailable()
        {
            response.Message.Add("Book with given id not found!");
        }
        private void Success()
        {
            response.Message.Add("success");
        }
        private void CheckGivenId()
        {
            response.Message.Add("Requested Id can't be negative.");
        }
        private void Forbidden()
        {
            response.Status = 403;
        }

    }
}
