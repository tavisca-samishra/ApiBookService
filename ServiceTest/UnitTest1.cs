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
        Book bookWithNegativeId = new Book()
        {
            Id = -2,
            Author = "Chetan Bhagat",
            Title = "Three mistakes of my life",
            Price = 300,
            Genre = "Fiction"
        };
        Book bookWithUnavailableId = new Book()
        {
            Id = 10,
            Author = "Chetan Bhagat",
            Title = "Three mistakes of my life",
            Price = 300,
            Genre = "Fiction"
        };
        Book bookWithNegativePrice = new Book()
        {
            Id = 5,
            Author = "Chetan Bhagat",
            Title = "Three mistakes of my life",
            Price = -300,
            Genre = "Fiction"
        };
        Book bookWithInvalidAuthor = new Book()
        {
            Id = -2,
            Author = "Chetan23 Bhagat",
            Title = "Three mistakes of my life",
            Price = 300,
            Genre = "Fiction"
        };
        Book bookWithInvalidTitle = new Book()
        {
            Id = 5,
            Author = "Chetan Bhagat",
            Title = "Three mistakes344 of my life",
            Price = 300,
            Genre = "Fiction"
        };
        Book bookWithInvalidGenre = new Book()
        {
            Id = 5,
            Author = "Chetan Bhagat",
            Title = "Three mistakes of my life",
            Price = 300,
            Genre = "Ficti324on"
        };
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
            NegativeId();
        }

        private void NegativeId()
        {
            Assert.Equal("Id can't be negative.", response.Message);
        }

        [Fact]
        public void Test_GetBook_Method_With_Unavailable_Id()
        {
            response = bookService.GetBook(10);
            UnavailableId();
        }

        private void UnavailableId()
        {
            Assert.Equal("Book with given id not found!", response.Message);
        }

        [Fact]
        public void Test_GetBook_Method_With_Valid_Available_Id()
        {
            response = bookService.GetBook(3);
            Valid();
        }

        private void Valid()
        {
            Assert.Equal("success", response.Message);
        }
        [Fact]
        public void Test_GetBook_Method()
        {
            response = bookService.GetBook(3);
            Assert.Equal("Fiction", response.Book.Genre);
        }
        [Fact]
        public void Test_AddBook_Method_With_Negative_Id()
        {
            response = bookService.AddBook(bookWithNegativeId);
            NegativeId();
        }

        [Fact]
        public void Test_AddBook_Method_With_Valid_Id()
        {
            response = bookService.AddBook(book);
            Valid();
        }

        [Fact]
        public void Test_AddBook_Method_With_Negative_Price()
        {
            response = bookService.AddBook(bookWithNegativePrice);
            NegativePrice();
        }

        private void NegativePrice()
        {
            Assert.Equal("Price can't be negative.", response.Message);
        }

        [Fact]
        public void Test_AddBook_Method_With_Valid_Price()
        {
            response = bookService.AddBook(book);
            Valid();
        }
        [Fact]
        public void Test_AddBook_Method_With_Invalid_Author()
        {
            response = bookService.AddBook(bookWithInvalidAuthor);
            InvalidText();
        }

        private void InvalidText()
        {
            Assert.Equal("Name, Category and Author: should contain only alphabets.", response.Message);
        }

        [Fact]
        public void Test_AddBook_Method_With_Valid_Author()
        {
            response = bookService.AddBook(book);
            Valid();
        }
        [Fact]
        public void Test_AddBook_Method_With_Invalid_Title()
        {
            response = bookService.AddBook(bookWithInvalidTitle);
            InvalidText();
        }
        [Fact]
        public void Test_AddBook_Method_With_Valid_Title()
        {
            response = bookService.AddBook(book);
            Valid();
        }
        [Fact]
        public void Test_AddBook_Method_With_Invalid_Genre()
        {
            response = bookService.AddBook(bookWithInvalidGenre);
            InvalidText();
        }
        [Fact]
        public void Test_AddBook_Method_With_Valid_Genre()
        {
            response = bookService.AddBook(book);
            Valid();
        }
        [Fact]
        public void Test_UpdateBook_Method_With_Negative_Id()
        {
            response = bookService.UpdateBook(-3,book);
            NegativeId();
        }
        [Fact]
        public void Test_UpdateBook_Method_With_Unavailable_Id()
        {
            response = bookService.UpdateBook(10,book);
            UnavailableId();
        }
        [Fact]
        public void Test_UpdateBook_Method_With_Valid_Available_Id()
        {
            response = bookService.UpdateBook(5,book);
            Valid();
        }

        [Fact]
        public void Test_UpdateBook_Method_With_Negative_Price()
        {
            response = bookService.UpdateBook(5,bookWithNegativePrice);
            NegativePrice();
        }
        [Fact]
        public void Test_UpdateBook_Method_With_Valid_Price()
        {
            response = bookService.UpdateBook(5, book);
            Valid();
        }
        [Fact]
        public void Test_UpdateBook_Method_With_Invalid_Author()
        {
            response = bookService.UpdateBook(5, bookWithInvalidAuthor);
            InvalidText();
        }
        [Fact]
        public void Test_UpdateBook_Method_With_Valid_Author()
        {
            response = bookService.UpdateBook(5, book);
            Valid();
        }
        [Fact]
        public void Test_UpdateBook_Method_With_Invalid_Title()
        {
            response = bookService.UpdateBook(5, bookWithInvalidTitle);
            InvalidText();
        }
        [Fact]
        public void Test_UpdateBook_Method_With_Valid_Title()
        {
            response = bookService.UpdateBook(5, book);
            Valid();
        }
        [Fact]
        public void Test_UpdateBook_Method_With_Invalid_Genre()
        {
            response = bookService.UpdateBook(5, bookWithInvalidGenre);
            InvalidText();
        }
        [Fact]
        public void Test_UpdateBook_Method_With_Valid_Genre()
        {
            response = bookService.UpdateBook(5, book);
            Valid();
        }
        [Fact]
        public void Test_RemoveBooks_Method_With_Negative_Id()
        {
            response = bookService.RemoveBooks(-2);
            NegativeId();
        }
        [Fact]
        public void Test_RemoveBooks_Method_With_Unavailable_Id()
        {
            response = bookService.RemoveBooks(10);
            UnavailableId();
        }
    }
}
