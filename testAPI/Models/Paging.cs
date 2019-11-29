using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace swaggerAPIClone.Models
{
    public class Paging
    {
        public int totalItems { get; set; }
        public int pageNumber { get; set; }
        public int pageSize { get; set; }
        public int totalPages { get; set; }

        public Paging(int totalItems, int pageNumber, int pageSize)
        {
            this.totalItems = totalItems;
            this.pageNumber = pageNumber;
            this.pageSize = pageSize;
            this.totalPages = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(this.totalItems) / Convert.ToDouble(this.pageSize)));
        }

        public void setup(int totalItems, int pageNumber, int pageSize)
        {
            this.totalItems = totalItems;
            this.pageNumber = pageNumber;
            this.pageSize = pageSize;
            this.totalPages = (int)Math.Ceiling(Convert.ToDouble(this.totalItems / this.pageSize));
        }
    }
}