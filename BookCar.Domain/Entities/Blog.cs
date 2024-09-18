﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCar.Domain.Entities
{
    public class Blog
    {
        public int BlogId { get; set; }
        public string Title { get; set; }
        public int AuthorId{ get; set; }
        public Author Author{ get; set; }
        public string CoverImageUrl{ get; set; }
        public DateTime CreatedDate{ get; set; }
        public int CategoryId{ get; set; }
        public Category Category { get; set; }
        public string BlogDescription { get; set; }
        public List<TagCloud> TagClouds { get; set; }
    }
}
