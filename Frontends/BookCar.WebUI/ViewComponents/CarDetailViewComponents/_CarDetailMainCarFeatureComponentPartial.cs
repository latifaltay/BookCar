using BookCar.Dto.CarDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;

namespace BookCar.WebUI.ViewComponents.CarDetailViewComponents
{
	public class _CarDetailMainCarFeatureComponentPartial(IHttpClientFactory _httpClientFactory) : ViewComponent
	{
		public async Task<IViewComponentResult> InvokeAsync(int id)
		{
			ViewBag.carid = id;
			var client = _httpClientFactory.CreateClient();
			var resposenMessage = await client.GetAsync($"https://localhost:7028/api/Cars/{id}");
			if (resposenMessage.IsSuccessStatusCode)
			{
				var jsonData = await resposenMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<ResultCarWithBrandsDto>(jsonData);
				return View(values);
			}
			return View();
		}
	}
}
