using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using Tulet.Models.Entities;

namespace Tulet.Models.HomeViewModels
{
    public class HomeViewModel
    {
        /*public string Banner { get; set; }
        public string Advert1 { get; set; }
        public string Advert2 { get; set; }
        public string Advert3 { get; set; }*/

        public ICollection<Post> Sale {get; set;}
        public ICollection<Post> Rent {get; set;}
        public ICollection<Post> Lease {get; set;}
    }
}