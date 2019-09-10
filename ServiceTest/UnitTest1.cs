using System;
using WebApplication1;
using WebApplication1.Models;
using Xunit;

namespace ServiceTest
{
    public class UnitTest1
    {
        BookService bookService = new BookService();
        Response response;
       
        Book book = new Book()
        {
            Id = 5,
            Author = "Chetan Bhagat",
            Title = "Three mistakes of my life",
            Price = 300,
            Genre = "Fiction"
        };
        [Fact]
        public void Test_GetBook_Method_With_Negative_Id()
        {
            response = bookService.GetBook(-2);
            GivenNegativeId();
        }

        private void GivenNegativeId()
        {
            Assert.Equal("Requested Id can't be negative.", response.Message[0]);
        }

        [Fact]
        public void Test_GetBook_Method_With_Unavailable_Id()
        {
            response = bookService.GetBook(10);
            UnavailableId();
        }

        private void UnavailableId()
        {
            Assert.Equal("Book with given id not found!", response.Message[0]);
        }

        [Fact]
        public void Test_GetBook_Method_With_Valid_Available_Id()
        {
            response = bookService.GetBook(3);
            Valid();
        }

        private void Valid()
        {
            Assert.Equal("success", response.Message[0]);
        }
        [Fact]
        public void Test_GetBook_Method()
        {
            response = bookService.GetBook(3);
            Assert.Equal("Fiction", response.Book.Genre);
        }

        [Fact]
        public void Test_AddBook_Method()
        {
            response = bookService.AddBook(book);
            Valid();
        }
     
        [Fact]
        public void Test_UpdateBook_Method_With_Given_Negative_Id()
        {
            response = bookService.UpdateBook(-3, book);
            GivenNegativeId();
        }
        [Fact]
        public void Test_UpdateBook_Method_With_Unavailable_Id()
        {
            response = bookService.UpdateBook(10,book);
            UnavailableId();
        }
        [Fact]
        public void Test_UpdateBook_Method()
        {
            response = bookService.UpdateBook(5,book);
            Valid();
        }

      
        [Fact]
        public void Test_RemoveBooks_Method_With_Given_Negative_Id()
        {
            response = bookService.RemoveBooks(-2);
            GivenNegativeId();
        }
        [Fact]
        public void Test_RemoveBooks_Method_With_Unavailable_Id()
        {
            response = bookService.RemoveBooks(10);
            UnavailableId();
        }
        [Fact]
        public void Test_RemoveBooks_Method()
        {
            response = bookService.RemoveBooks(5);
            Valid();
        }
    }
}
