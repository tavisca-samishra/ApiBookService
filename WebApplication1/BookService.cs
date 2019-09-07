using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        private void Forbidden()
        {
            response.Status = 403;
        }

        private void IdNotAvailable()
        {
            response.Message.Add("Book with given id not found!");
        }

        private void Success()
        {
            response.Message.Add("success");
        }

        public Response AddBook(Book book)
        {
            if (book.Author.Any(char.IsDigit))
            {
                CheckAuthor();
            }
            if (book.Title.Any(char.IsDigit))
            {
                CheckTitle();
            }
            if (book.Genre.Any(char.IsDigit))
            {
                CheckCategory();
            }
            if (book.Id < 0)
            {
                CheckId();
            }
            if (book.Price < 0)
            {
                CheckPrice();
            }
            if (response.Message.Count == 0)
            {
                BookData.PostBook(book);
                response.Status = 201;
                Success();
            }
            else
            {
                BadRequest();
            }
            return response;
        }

        private void BadRequest()
        {
            response.Status = 400;
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

            if (book.Author.Any(char.IsDigit))
            {
                CheckAuthor();
            }
            if (book.Title.Any(char.IsDigit))
            {
                CheckTitle();
            }
            if (book.Genre.Any(char.IsDigit))
            {
                CheckCategory();
            }
            if (book.Id < 0)
            {
                CheckId();
            }
            if (book.Price < 0)
            {
                CheckPrice();
            }
            if (response.Message.Count == 0)
            {
                Success();
                response.Status = 202;
                BookData.UpdateBooks(id, book);
            }
            else
            {
                if (response.Status != 403)
                    BadRequest();
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
            else
            {
                if (response.Status != 403)
                    BadRequest();
            }
            return response;
        }

        private void CheckGivenId()
        {
            response.Message.Add("Requested Id can't be negative.");
        }

        private void CheckPrice()
        {
            response.Message.Add("Price can't be negative.");
        }

        private void CheckId()
        {
            response.Message.Add("Id can't be negative.");
        }

        private void CheckTitle()
        {
            response.Message.Add("Title should only contain alphabets.");
        }
        private void CheckCategory()
        {
            response.Message.Add("Category should only contain alphabets.");
        }
        private void CheckAuthor()
        {
            response.Message.Add("Author should only contain alphabets.");
        }

    }
}
