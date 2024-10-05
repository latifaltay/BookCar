using Microsoft.AspNetCore.SignalR;

namespace BookCar.WebApi.Hubs
{
    public class CarHub(IHttpClientFactory _httpClientFactory) : Hub
    {
        public async Task SendCarCount()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7028/api/Statistics/GetCarCount");
            var value = await responseMessage.Content.ReadAsStringAsync();
            await Clients.All.SendAsync("ReceiveCarCount", value);
        }
    }
}
