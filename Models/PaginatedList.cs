
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Tulet.Models
{
    public class PaginatedList<T> : List<T>
    {
        int pageIndex;
        int totalPages;

        public PaginatedList(List<T> items,int Count,int PageIndex,int PageSize) 
        {
            this.pageIndex = PageIndex;
            this.totalPages = (int)Math.Ceiling(Count / (double)PageSize);
            this.AddRange(items);
        }

        public bool hasPrevious
        {
            get {return pageIndex > 1;}
        }
        
        public bool hasNext
        {
            get {return pageIndex < totalPages;}
        }

        public static PaginatedList<T> Create(List<T> items,int PageIndex,int pageSize) 
        {
            var count = items.Count();
            var result = items.Skip(pageSize * (PageIndex - 1)).Take(pageSize).ToList(); 
            return new PaginatedList<T>(items,count,PageIndex,pageSize);
        }

        
    }   
}