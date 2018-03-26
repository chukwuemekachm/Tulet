using System.Collections.Generic;
using Tulet.Models.Entities;

namespace Tulet.Models.AdminViewModels
{
    public class CategoryViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Category> category;
    }
}