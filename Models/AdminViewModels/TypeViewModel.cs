using System.Collections.Generic;
using Tulet.Models.Entities;

namespace Tulet.Models.AdminViewModels
{
    public class TypeViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Type> type;
    }
}