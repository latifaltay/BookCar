using BookCar.Application.Features.RepositoryPattern;
using BookCar.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookCar.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController(IGenericRepository<Comment> _repository) : ControllerBase
    {
        [HttpGet]
        public IActionResult CommentList() 
        {
            var values = _repository.GetAll();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateComment(Comment comment) 
        {
            _repository.Create(comment);
            return Ok("Yorum Başarıyla Eklendi!");
        }

        [HttpDelete]
        public IActionResult DeleteComment(int id) 
        {
            var value = _repository.GetById(id);
            _repository.Remove(value);
            return Ok("Yorum Başarıyla Silindi!");
        }

        [HttpPut]
        public IActionResult UpdateComment(Comment comment) 
        {
            _repository.Update(comment);
            return Ok("Yorum Başarıyla Güncellendi!");
        }

        [HttpGet("{id}")]
        public IActionResult GetComment(int id) 
        {
            var value = _repository.GetById(id);
            return Ok(value);
        }

        [HttpGet("CommentListByBlog")]
        public IActionResult CommentListByBlog(int id)
        {
            var value = _repository.GetCommetByBlogId(id);
            return Ok(value);
        }
    }
}
