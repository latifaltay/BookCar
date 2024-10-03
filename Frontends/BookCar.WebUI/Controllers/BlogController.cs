using BookCar.Dto.BlogDtos;
using BookCar.Dto.CarPricingDtos;
using BookCar.Dto.CommentDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace BookCar.WebUI.Controllers
{
    public class BlogController(IHttpClientFactory _httpClientFactory) : Controller
    {
        public async Task<IActionResult> Index()
        {
            ViewBag.v1 = "Bloglar";
            ViewBag.v2 = "Yazarlarımızın Bloglar";


            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7028/api/Blogs/GetAllBlogsWithAuthorList");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultAllBlogsWithAuthorDto>>(jsonData);
                return View(values);
            }
            // Eğer veriyi çekemezsen ama yine de sayfanın yüklenmesini istersen hiç bir koşulda sayfa hata vermesin istersen veri çekerken hata oluşursa boş bir liste dönebilirsin
            //var test = new List<ResultAllBlogsWithAuthorDto>();
            //return View(test);
            return View();
        }

        public async Task<IActionResult> BlogDetail(int id) 
        {
            ViewBag.v1 = "Bloglar";
            ViewBag.v2 = "Blog Detayı ve Yorumlar";
            ViewBag.blogId = id;


            var client = _httpClientFactory.CreateClient();
            var responseMessage2 = await client.GetAsync("https://localhost:7028/api/Comments/CommentCountByBlog?id=" + id);
            var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
            //var values2 = JsonConvert.DeserializeObject<GetBlogById>(jsonData2);
            ViewBag.commentCount = jsonData2;

            return View();
        }


        [HttpGet]
        public PartialViewResult AddComment(int id)
        {
            ViewBag.blogId = id;
            return PartialView();
        }


        [HttpPost]
        public async Task<IActionResult> AddComment(CreateCommentDto createCommentDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createCommentDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7028/api/Comments/CreateCommentWithMediator", stringContent);
            if (responseMessage.IsSuccessStatusCode) 
            {
                return RedirectToAction("Index", "Default");
            }
            return View();
        }
    }
}
