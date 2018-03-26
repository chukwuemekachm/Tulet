using System;

namespace Tulet.Models.AdminViewModels
{
    public class UserViewModel
    {
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
    }
}