using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookSubscription.Models
{
    public class Book
    {
        public string Name { get; set; }
        public string Text { get; set; }
        public double Price { get; set; }
        public DateTime SubscriptionStartDate { get; set; }
        public DateTime SubscriptionEndDate { get; set; }
        public string SubscriptionType { get; set; }
    }
}