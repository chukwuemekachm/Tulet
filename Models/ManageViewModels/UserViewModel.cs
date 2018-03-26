using System;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Tulet.Models.ManageViewModels
{
    public class UserViewModel 
    {
        [Required]
        [Display(Name = "First Name")]
        [StringLength(20, ErrorMessage = "The First Name must be at least 3 and at max 20 characters long.", MinimumLength = 3)]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        [StringLength(20, ErrorMessage = "The Last Name must be at least 3 and at max 20 characters long.", MinimumLength = 3)]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Address")]
        [StringLength(50, ErrorMessage = "The Address must be at least 10 and at max 50 characters long.", MinimumLength = 10)]
        public string Address { get; set; }

        [Required]
        [Display(Name = "Date Of Birth")]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        [Required]
        [Display(Name = "Phone")]
        [StringLength(11, ErrorMessage = "The Phone number must be at least 9 and at max 11 characters long.", MinimumLength = 9)]
        public string Phone { get; set; }
        
        [Display(Name = "Profile Picture")]
        public IFormFile Photo { get; set; }

        public string PhotoUrl { get; set; }

        public string StatusMessage { get; set; }
    }
}