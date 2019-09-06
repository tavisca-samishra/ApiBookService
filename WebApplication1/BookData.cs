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

        public static void PostBook(Book book)
        {
            ReadJson();
            bookList.Add(book);
            WriteJson();
        }
        public static IEnumerable<Book> GetBooks()
        {
            ReadJson();
            return bookList;
        }

        public static void RemoveBookById(int id)
        {
            ReadJson();
            for (int i = 0; i < bookList.Count; i++)
            {
                if (bookList[i].Id == id)
                {
                    bookList.RemoveAt(i);
                }
            }
            WriteJson();
        }

        public static void UpdateBooks(int id, Book book)
        {
            ReadJson();
            for (int i = 0; i < bookList.Count; i++)
            {
                if (bookList[i].Id == id)
                    bookList[i] = book;
            }
            WriteJson();
        }

        private static void WriteJson()
        {
            string json = JsonConvert.SerializeObject(bookList.ToArray());
            File.WriteAllText(@"C:\Users\smishra\source\repos\WebApplication1\ServiceTest\bin\Debug\netcoreapp2.1\bookData.json", json);
        }

        private static void ReadJson()
        {
            using (StreamReader r = new StreamReader(@"C:\Users\smishra\source\repos\WebApplication1\ServiceTest\bin\Debug\netcoreapp2.1\bookData.json"))
            {
                string jsons = r.ReadToEnd();
                bookList = JsonConvert.DeserializeObject<List<Book>>(jsons);
            }
        }

    }
}
