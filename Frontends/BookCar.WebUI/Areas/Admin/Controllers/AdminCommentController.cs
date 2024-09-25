using BookCar.Dto.CommentDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;

namespace BookCar.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/AdminComment")]
    public class AdminCommentController(IHttpClientFactory _httpClientFactory) : Controller
    {
        [Route("Index/{id}")]
        public async Task<IActionResult> Index(int id)
        {
            ViewBag.v = id;
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7028/api/Comments/CommentListByBlog?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCommentDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
