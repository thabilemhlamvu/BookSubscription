using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookSubscription.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string userName { get; set; }
        public string passWord { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string emailAddress { get; set; }
       
    }
}