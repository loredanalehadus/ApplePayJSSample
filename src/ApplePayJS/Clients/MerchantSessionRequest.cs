using Newtonsoft.Json;

namespace JustEat.ApplePayJS.Clients
{
    public class MerchantSessionRequest
    {
        [JsonProperty("merchantIdentifier")]
        public string MerchantIdentifier { get; set; }

        [JsonProperty("initiativeContext")]
        public string DomainName { get; set; }

        [JsonProperty("displayName")]
        public string DisplayName { get; set; }

        [JsonProperty("initiative")]
        public string Initiative => "web";
    }
}
