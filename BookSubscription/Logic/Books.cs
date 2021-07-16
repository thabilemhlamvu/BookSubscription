using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookSubscription.Logic
{
    public class Books
    {
        public static List<Models.Book> GetBookList(string username,string password)
        {
            return DataAccess.Books.GetBookList(username,password);
        }
        public static void SaveBook (Models.Book item )
        {
             DataAccess.Books.SaveBook(item);
        }
    }
}