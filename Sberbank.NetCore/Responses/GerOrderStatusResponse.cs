using Newtonsoft.Json;
using Sberbank.NetCore.Tools;

namespace Sberbank.NetCore.Responses
{
    public class GerOrderStatusResponse : RestResponse
    {
        [JsonProperty("OrderStatus")]
        public PaymentStatus OrderStatus { get; set; }

        [JsonProperty("OrderNumber")]
        public string OrderNumber { get; set; }

        [JsonProperty("Pan")]
        public string Pan { get; set; }

        [JsonProperty("expiration")]
        public string Expiration { get; set; }

        [JsonProperty("cardholderName")]
        public string CardholderName { get; set; }

        [JsonProperty("Amount")]
        public int MinorAmount
        {
            get => Amount.MinorFormat;
            set => Amount = new Price(value);
        }

        [JsonProperty("depositAmount")]
        public int MinorDepositedAmount
        {
            get => DepositedAmount.MinorFormat;
            set => DepositedAmount = new Price(value);
        }

        [JsonProperty("currency")]
        public Currency Currency { get; set; }

        [JsonProperty("approvalCode")]
        public string ApprovalCode { get; set; }

        [JsonProperty("authCode")]
        public int AuthCode { get; set; }

        [JsonProperty("Ip")]
        public string Ip { get; set; }

        [JsonProperty("clientId")]
        public string ClientId { get; set; }

        [JsonProperty("bindingId")]
        public string BindingId { get; set; }

        public GerOrderStatusResponse() : base()
        {
            OrderNumber = string.Empty;

            Pan = string.Empty;
            Expiration = string.Empty;
            CardholderName = string.Empty;

            Amount = Price.Zero;
            DepositedAmount = Price.Zero;
            Currency = Currency.USD;

            ApprovalCode = string.Empty;

            Ip = string.Empty;

            ClientId = string.Empty;
            BindingId = string.Empty;
        }

        [JsonIgnore]
        public Price DepositedAmount { get; set; }

        [JsonIgnore]
        public Price Amount { get; set; }
    }
}
