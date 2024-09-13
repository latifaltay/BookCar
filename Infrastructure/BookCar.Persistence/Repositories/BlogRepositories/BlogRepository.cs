using BookCar.Application.Interfaces.BlogInterfaces;
using BookCar.Domain.Entities;
using BookCar.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCar.Persistence.Repositories.BlogRepositories
{
    public class BlogRepository(BookCarContext _context) : IBlogRepository
    {
        public List<Blog> GetBlogsWithAuthors()
        {
            var values = _context.Blogs.Include(x => x.Author).Include(x => x.Category).ToList();
            return values;
        }

        public List<Blog> GetLast3BlogsWithAuthors() 
        { 
            var value = _context.Blogs.Include(c => c.Author).OrderByDescending(x => x.BlogId).Take(3).ToList(); 
            return value; 
        }
    }
}
