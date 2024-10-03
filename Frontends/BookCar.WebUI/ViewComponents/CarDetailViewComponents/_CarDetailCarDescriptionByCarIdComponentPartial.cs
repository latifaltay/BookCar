using BookCar.Dto.CarDescriptionDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BookCar.WebUI.ViewComponents.CarDetailViewComponents
{
	public class _CarDetailCarDescriptionByCarIdComponentPartial(IHttpClientFactory _httpClientFactory) : ViewComponent
	{
		public async Task<IViewComponentResult> InvokeAsync(int id)
		{
			ViewBag.carid = id;
			var client = _httpClientFactory.CreateClient();
			var resposenMessage = await client.GetAsync($"https://localhost:7028/api/CarDescriptions?id=" + id);
			if (resposenMessage.IsSuccessStatusCode)
			{
				var jsonData = await resposenMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<ResultCarDescriptionByCarIdDto>(jsonData);
				return View(values);
			}
			return View();
		}
	}
}
