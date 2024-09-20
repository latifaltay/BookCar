using BookCar.Application.Interfaces.TagCloudInterfaces;
using BookCar.Domain.Entities;
using BookCar.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCar.Persistence.Repositories.TagCloudRepositories
{
    public class TagCloudRepository(BookCarContext _context) : ITagCloudRepository
    {
        public List<TagCloud> GetTagCloudsByBlogId(int id)
        {
            var values = _context.TagClouds.Where(x => x.BlogId == id).ToList();
            return values;
        }
    }
}
