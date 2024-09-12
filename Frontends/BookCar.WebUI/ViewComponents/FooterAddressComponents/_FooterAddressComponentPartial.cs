using BookCar.Dto.AboutDtos;
using BookCar.Dto.FooterAddressDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BookCar.WebUI.ViewComponents.FooterAddressComponents
{
	public class _FooterAddressComponentPartial(IHttpClientFactory _httpClientFactory) : ViewComponent
	{
		public async Task<IViewComponentResult> InvokeAsync() 
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7028/api/FooterAddresses");

			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultFooterAddressDto>>(jsonData);
				return View(values);
			}

			return View();
		}
	}
}
