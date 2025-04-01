using LotteriesDigitalApi.Application.Common.Interfaces.Services;
using Newtonsoft.Json;

namespace LotteriesDigitalApi.Infrastructure.Services.ThirdPartytTicketSeller
{
    public class ThirdPartyTicketSeller : ITicketProvider
    {
        private readonly HttpClient _httpClient;

        public ThirdPartyTicketSeller(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }


        public async Task<decimal> PurchaseTicket(int Drawid, int NumberofTickets, Guid RequestID)
        {
            HttpRequestMessage message = new HttpRequestMessage();
            message.Method = HttpMethod.Post;
            message.RequestUri = new Uri("Https://thirdparty/purchase/tickets");

            var request = new
            {
                Drawid,
                NumberofTickets,
                RequestID
            };

            message.Content = new StringContent(JsonConvert.SerializeObject(request), System.Text.Encoding.UTF8, "application/json");


            //var response = await _httpClient.SendAsync(message);
            var response = await ThirdPartyAPI.PurchaseTicketFromSeller(Drawid, NumberofTickets, RequestID);

            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                var apiResponse = JsonConvert.DeserializeObject<ThirdPartyTicketSellerResponse>(jsonResponse);
                return apiResponse.TotalCost;
            }
            else
            {
                return -1;
            }

        }
    }
}
