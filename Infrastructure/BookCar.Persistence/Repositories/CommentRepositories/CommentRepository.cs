using BookCar.Application.Features.RepositoryPattern;
using BookCar.Domain.Entities;
using BookCar.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCar.Persistence.Repositories.CommentRepositories
{
    public class CommentRepository<T>(BookCarContext _context) : IGenericRepository<Comment>
    {
        public void Create(Comment entity)
        {
            _context.Add(entity);
            _context.SaveChanges();
        }

        public List<Comment> GetAll()
        {
            return _context.Comments.Select(x => new Comment
            {
                CommentId = x.CommentId,
                BlogId = x.BlogId,
                CreatedDate = x.CreatedDate,
                Description = x.Description,
                Name = x.Name,
            }).ToList();
        }

        public Comment GetById(int id)
        {
            return _context.Comments.Find(id);
        }

        public List<Comment> GetCommetByBlogId(int id)
        {
            return _context.Set<Comment>().Where(x => x.BlogId == id).ToList();   
        }

        public void Remove(Comment entity)
        {
            var value = _context.Comments.Find(entity.CommentId);
            _context.Comments.Remove(value);
            _context.SaveChanges();
        }

        public void Update(Comment entity)
        {
            _context.Comments.Update(entity);
            _context.SaveChanges();
        }
    }
}
