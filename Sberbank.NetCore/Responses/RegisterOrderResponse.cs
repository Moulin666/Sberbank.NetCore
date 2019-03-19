using Newtonsoft.Json;

namespace Sberbank.NetCore.Responses
{
    public class RegisterOrderResponse : RestResponse
    {
        [JsonProperty("orderId")]
        public string OrderId { get; set; }

        [JsonProperty("formUrl")]
        public string FormUrl { get; set; }

        public RegisterOrderResponse() : base()
        {
            OrderId = string.Empty;
            FormUrl = string.Empty;
        }
    }
}
