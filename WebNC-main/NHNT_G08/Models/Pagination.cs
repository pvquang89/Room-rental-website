using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace NHNT_G08.Models
{
    public class Pagination<T>:List<T>
    {
        public int PageIndex { get; set; }
        public int totalPages { get; set; }
        public Pagination(List<T> items, int count, int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            totalPages = (int)Math.Ceiling(count / (double)pageSize);
            this.AddRange(items);
        }
        public bool HasPreviousPage => PageIndex > 1;
        public bool HasNextPage => PageIndex < totalPages;

        public static Pagination<T> Create (List<T> source, int pageIndex, int pageSize) 
        {
            var count = source.Count;
            var items = source.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
            return new Pagination<T>(items, count, pageIndex, pageSize);
        }
        
    }
}
