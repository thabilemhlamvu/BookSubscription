using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using BookSubscription.Constant;

namespace BookSubscription.Controllers
{
    [AllowAnonymous]
    public class BooksController : ApiController
    {
        [Route("api/books/{username}/{password}")]
        public IEnumerable<Models.Book> Get(string username,string password)
        {

            return Logic.Books.GetBookList(username,password);
        }
        // GET api/books
        //public IEnumerable<Models.Book> Get()
        //{
        //    return Logic.Books.GetList();
        //}

        [Route("api/books/")]
        public void Post([FromBody]Models.Book value)
        {
             Logic.Books.SaveBook(value);
        }


    }
}
