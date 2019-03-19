using Sberbank.NetCore.Integration.Interfaces;
using Sberbank.NetCore.Tools;
using System.Collections.Generic;

namespace Sberbank.NetCore.Integration.Implementation
{
    public class RefundParameters : IParameters
    {
        public static class Keys
        {
            public static readonly string OrderId = "orderId";
            public static readonly string Amount = "amount";
        }

        public string OrderId { get; set; }

        public Price Amount { get; set; }

        public RefundParameters() : this(string.Empty, Price.Zero) { }

        public RefundParameters(string orderId, Price amount)
        {
            OrderId = orderId;
            Amount = amount;
        }

        Dictionary<string, object> IParameters.CollectParameters ()
            => new Dictionary<string, object>
            {
                {
                    Keys.OrderId, OrderId
                },
                {
                    Keys.Amount, $"{Amount.MinorFormat}"
                }
            };
    }
}
