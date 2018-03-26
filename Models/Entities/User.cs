using System;
using System.Collections.Generic;

namespace Tulet.Models.Entities
{
    public partial class User
    {
        public User()
        {
            Post = new HashSet<Post>();
            Subscription = new HashSet<Subscription>();
            Verification = new HashSet<Verification>();
        }

        public string UserId { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public DateTime BirthDate { get; set; }
        public string Phone { get; set; }
        public bool Verified { get; set; }
        public bool Active { get; set; }
        public string Photo { get; set; }
        public DateTime RegDate { get; set; }

        public ICollection<Post> Post { get; set; }
        public ICollection<Subscription> Subscription { get; set; }
        public ICollection<Verification> Verification { get; set; }
    }
}
