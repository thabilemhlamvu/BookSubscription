using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookSubscription.Constant
{
    /// <summary>
    /// Base API Route definition
    /// </summary>
    public class ApiContollerRoutes
    {
        /// <summary>
        /// Base URL for the Book subscription API
        /// </summary>
        public const string BaseUri = "api/books/";

    }
    public class BookControllerRoutes:ApiContollerRoutes
    {
        public const string bookSubscription = BaseUri;
    }
}