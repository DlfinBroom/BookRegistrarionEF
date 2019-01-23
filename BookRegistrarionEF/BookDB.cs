using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRegistrarionEF {
    static class BookDB {
        public static List<Book> GetAllBooks() {

            // Create a context object to connect and query the DB
            BookRegContext context = new BookRegContext();

            // Use LINQ to query the database using the context
            //List<Book> allBooks = (
            //    from boo in context.Book
            //    select boo ).ToList();

            List<Book> allBooks = context.Book.ToList();

            return allBooks;
        }

        public static void AddBook(Book boo) {
            BookRegContext context = new BookRegContext();

            // Create insert query
            // Adds insert to a list of pending queries
            context.Book.Add(boo);

            // Executes all pending queries
            context.SaveChanges();
        }
    }
}
