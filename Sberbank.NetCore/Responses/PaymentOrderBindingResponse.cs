using Newtonsoft.Json;

namespace Sberbank.NetCore.Responses
{
    public class PaymentOrderBindingResponse : RestResponse
    {
        [JsonProperty("redirect")]
        public string Redirect { get; set; }

        [JsonProperty("info")]
        public string Info { get; set; }

        [JsonProperty("error")]
        public string Error { get; set; }

        [JsonProperty("acsUrl")]
        public string AcsUrl { get; set; }

        [JsonProperty("paReq")]
        public string PaymentAuthentificationRequest { get; set; }

        [JsonProperty("termUrl")]
        public string TermUrl { get; set; }

        public PaymentOrderBindingResponse() : base() { }
    }
}
