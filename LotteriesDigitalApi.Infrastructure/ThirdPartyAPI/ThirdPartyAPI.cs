using Newtonsoft.Json;


namespace LotteriesDigitalApi.Infrastructure
{
    public static class ThirdPartyAPI
    {
        public static async Task<HttpResponseMessage> PurchaseTicketFromSeller(int Drawid, int NumberofTickets, Guid RequestID)
        {
            HttpResponseMessage response = new HttpResponseMessage();

            await Task.CompletedTask;
            // Validate input - If the number of tickets is divisible by 3, return a 400 BadRequest.
            if (NumberofTickets % 3 == 0)
            {
                response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                return response;
            }

            // Calculate the total cost -  set as $5.20 a ticket
            var totalCost = (decimal)NumberofTickets * 5.20m;
            response.StatusCode = System.Net.HttpStatusCode.OK;
            var responseContent = new
            {
                TotalCost = totalCost
            };
            response.Content = new StringContent(JsonConvert.SerializeObject(responseContent), System.Text.Encoding.UTF8, "application/json");

            // Return 200 OK with the total cost as a response
            return response;
        }

    }
}
