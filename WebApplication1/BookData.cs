using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1
{
    public class BookData
    {
        public static List<Book> bookList;

        //= new List<Book>()
        //{
        //    new Book { Title = "Sapiens", Rating = 4, Genre = "History" },
        //    new Book { Title = "Grand Design", Rating = 5, Genre = "Science" },
        //    new Book { Title = "Harry Potter", Rating = 3, Genre = "Fiction" },
        //    new Book { Title = "C++", Rating = 4, Genre = "Coding" }
        //};

        public static void PostBook(Book book)
        {
            using (StreamReader r = new StreamReader(@"C:\Users\smishra\source\repos\WebApplication1\ServiceTest\bin\Debug\netcoreapp2.1\bookData.json"))
            {
                string jsons = r.ReadToEnd();
                bookList = JsonConvert.DeserializeObject<List<Book>>(jsons);
            }
            bookList.Add(book);
            string json = JsonConvert.SerializeObject(bookList.ToArray());
            File.WriteAllText(@"C:\Users\smishra\source\repos\WebApplication1\ServiceTest\bin\Debug\netcoreapp2.1\bookData.json", json);
        }

        public static IEnumerable<Book> GetBooks()
        {
            using (StreamReader r = new StreamReader(@"C:\Users\smishra\source\repos\WebApplication1\ServiceTest\bin\Debug\netcoreapp2.1\bookData.json"))
            {
                string json = r.ReadToEnd();
                bookList = JsonConvert.DeserializeObject<List<Book>>(json);
            }
            return bookList;
        }

        public static void RemoveBooksByGenre(int id)
        {
            using (StreamReader r = new StreamReader(@"C:\Users\smishra\source\repos\WebApplication1\ServiceTest\bin\Debug\netcoreapp2.1\bookData.json"))
            {
                string jsons = r.ReadToEnd();
                bookList = JsonConvert.DeserializeObject<List<Book>>(jsons);
            }
            for (int i = 0; i < bookList.Count; i++)
            {
                if (bookList[i].Id == id)
                {
                    bookList.RemoveAt(i);
                    break;
                }
            }
            string json = JsonConvert.SerializeObject(bookList.ToArray());
            File.WriteAllText(@"C:\Users\smishra\source\repos\WebApplication1\ServiceTest\bin\Debug\netcoreapp2.1\bookData.json", json);
        }

        public static void UpdateBooks(int id, Book book)
        {
            using (StreamReader r = new StreamReader(@"C:\Users\smishra\source\repos\WebApplication1\ServiceTest\bin\Debug\netcoreapp2.1\bookData.json"))
            {
                string jsons = r.ReadToEnd();
                bookList = JsonConvert.DeserializeObject<List<Book>>(jsons);
            }
            for (int i = 0; i < bookList.Count; i++)
            {
                if (bookList[i].Id == id)
                    bookList[i] = book;
            }

            string json = JsonConvert.SerializeObject(bookList.ToArray());
            File.WriteAllText(@"C:\Users\smishra\source\repos\WebApplication1\ServiceTest\bin\Debug\netcoreapp2.1\bookData.json", json);
        }
    }
}
