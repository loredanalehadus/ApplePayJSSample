using System.Text;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace JustEat.ApplePayJS.Clients
{
    public class ApplePayClient
    {
        private readonly HttpClient _httpClient;

        public ApplePayClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<JObject> GetMerchantSessionAsync(
            string validationUrl,
            MerchantSessionRequest request,
            CancellationToken cancellationToken = default)
        {
            var stringContent = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");

            // POST the data to create a valid Apple Pay merchant session.
            using (var response = await _httpClient.PostAsync(validationUrl, stringContent))
            {
                response.EnsureSuccessStatusCode();

                // Read the opaque merchant session JSON from the response body.
                return await response.Content.ReadAsAsync<JObject>();
            }
        }
    }
}
