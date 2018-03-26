using System;
using System.Collections.Generic;

namespace Tulet.Models.Entities
{
    public partial class Type
    {
        public Type()
        {
            Post = new HashSet<Post>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Post> Post { get; set; }
    }
}
