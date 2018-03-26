using System;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Tulet.Models.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Tulet.Models.ManageViewModels
{
    public class PostViewModel
    {
        [Required]
        [Display(Name = "Title")]
        [StringLength(45, ErrorMessage = "The Title must be at least 10 and at max 45 characters long.", MinimumLength = 10)]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Category")]
        public string Category { get; set; }

        [Required]
        [Display(Name = "Type")]
        public string Type { get; set; }
        [Required]
        [Display(Name = "Price")]
        public double Price { get; set; }
        [Required]
        [Display(Name = "Negotiable")]
        public bool Negotiable { get; set; }

        [Required]
        [Display(Name = "State")]
        public string State { get; set; }
        [Required]
        [Display(Name = "Location")]
        [StringLength(30, ErrorMessage = "The Location must be at least 4 and at max 30 characters long.", MinimumLength = 4)]
        public string Location { get; set; }
        [Required]
        [Display(Name = "Description")]
        [StringLength(120, ErrorMessage = "The Description must be at least 20 and at max 120 characters long.", MinimumLength = 20)]
        public string Description { get; set; }
        [Required]
        [Display(Name = "Photo One")]
        public IFormFile Photo1 { get; set; }
        [Display(Name = "Photo Two")]
        public IFormFile Photo2 { get; set; }
        [Display(Name = "Photo Three")]
        public IFormFile Photo3 { get; set; }

        public string StatusMessage { get; set; }

        public List<SelectListItem> Categories { get; set; }
        public List<SelectListItem> Types { get; set; }

        public List<SelectListItem> States = new List<SelectListItem>
        {
            new SelectListItem{Value = "Enugu", Text = "Enugu"},
            new SelectListItem{Value = "Abia", Text = "Abia"},
            new SelectListItem{Value = "Anambra", Text = "Anambra"},
            new SelectListItem{Value = "Ebonyi", Text = "Ebonyi"},
            new SelectListItem{Value = "Delta", Text = "Delta"},
            new SelectListItem{Value = "Imo", Text = "Imo"},
            new SelectListItem{Value = "Others", Text = "Others"}
        };
    }
}