using System;
using System.Collections.Generic;

namespace Tulet.Models.Entities
{
    public partial class Post
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }
        public string Type { get; set; }
        public double Price { get; set; }
        public bool Negotiable { get; set; }
        public string State { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public string Photo1 { get; set; }
        public string Photo2 { get; set; }
        public string Photo3 { get; set; }

        public DateTime PostDate { get; set; }

        public Category CategoryNavigation { get; set; }
        public Type TypeNavigation { get; set; }
        public User User { get; set; }
    }
}
