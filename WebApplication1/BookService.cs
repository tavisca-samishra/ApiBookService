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
                return CheckId();
            }
            foreach (var item in books)
            {
                if (item.Id == id)
                {
                    response.Book = item;
                    response.Message = "success";
                    return response;
                }
            }
            response.Message = "Book with given id not found!";
            return response;
        }
        public Response AddBook(Book book)
        {
            if (book.Author.Any(char.IsDigit) || book.Genre.Any(char.IsDigit) || book.Title.Any(char.IsDigit))
            {
                return CheckAlphabet();
            }
            if (book.Id < 0)
            {
                return CheckId();
            }
            if (book.Price < 0)
            {
                return CheckPrice();
            }
            BookData.PostBook(book);
            response.Message = "success";
            return response;
        }
        public Response UpdateBook(int id, Book book)
        {
            if (id < 0)
            {
                return CheckId();
            }
            foreach (var item in books)
            {
                if (item.Id == id)
                {
                    response.Message = "success";
                    break;
                }
                else
                {
                    response.Message = "Book with given id not found!";
                }
            }
            if (response.Message != "success")
                return response;
            else
            {
                if (book.Author.Any(char.IsDigit) || book.Genre.Any(char.IsDigit) || book.Title.Any(char.IsDigit))
                {
                    return CheckAlphabet();
                }
                if (book.Id < 0)
                {
                    return CheckId();
                }
                if (book.Price < 0)
                {
                    return CheckPrice();
                }
                BookData.UpdateBooks(id, book);
                return response;
            }
        }

        public Response RemoveBooks(int id)
        {
            if (id < 0)
            {
                return CheckId();
            }
            foreach (var item in books)
            {
                if (item.Id == id)
                {
                    response.Message = "success";
                    break;
                }
                else
                {
                    response.Message = "Book with given id not found!";
                }
            }
            if (response.Message != "success")
                return response;
            else
            {
                BookData.RemoveBookById(id);
                return response;
            }
        }
        private Response CheckPrice()
        {
            response.Message = "Price can't be negative.";
            return response;
        }

        private Response CheckId()
        {
            response.Message = "Id can't be negative.";
            return response;
        }

        private Response CheckAlphabet()
        {
            response.Message = "Name, Category and Author: should contain only alphabets.";
            return response;
        }

    }
}
