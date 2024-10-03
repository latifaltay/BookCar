using BookCar.Dto.CarFeatureDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;

namespace BookCar.WebUI.ViewComponents.CarDetailViewComponents
{
	public class _CarDetailCarFeatureByCarIdComponentPartial(IHttpClientFactory _httpClientFactory) : ViewComponent
	{
		public async Task<IViewComponentResult> InvokeAsync(int id)
		{
			ViewBag.carid = id;
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7028/api/CarFeatures?id=" + id);
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultCarFeatureByCarIdDto>>(jsonData);
				return View(values);
			}
			return View();
		}
	}
}
