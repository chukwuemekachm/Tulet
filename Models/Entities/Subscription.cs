using System;
using System.Collections.Generic;

namespace Tulet.Models.Entities
{
    public partial class Subscription
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string SubscriptionType { get; set; }
        public DateTime SubscriptionDate { get; set; }
        public DateTime ExpiryDate { get; set; }

        public User User { get; set; }
    }
}
