using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Tulet.Models.HomeViewModels
{
    public class SearchViewModel
    {
        [Display(Name = "Type")]
        public string Type { get; set; }  
        [Display(Name = "Category")] 
        public string Category { get; set; }
        [Display(Name = "Location")]   
        public string Location { get; set; }
        public int PageIndex { get; set; }

        public SearchViewModel() 
        {
            PageIndex = 1;
        }

        public List<SelectListItem> Categories {get; set;}

        public List<SelectListItem> Types {get; set;}

        public List<SelectListItem> Locations {get; set;}
    }
}