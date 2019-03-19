using Sberbank.NetCore.Integration.Interfaces;
using System.Collections.Generic;

namespace Sberbank.NetCore.Integration.Implementation
{
    public class PaymentOrderBindingParameters : IParameters
    {
        public static class Keys
        {
            public static readonly string OrderId = "mdOrder";
            public static readonly string BindingId = "bindingId";
            public static readonly string Language = "language";
            public static readonly string Ip = "ip";
            public static readonly string Cvc = "cvc";
            public static readonly string Email = "email";
        }

        public string OrderId { get; set; }
        public string BindingId { get; set; }
        public string Language { get; set; }
        public string Ip { get; set; }

        public int? Cvc { get; set; }
        public string Email { get; set; }

        public PaymentOrderBindingParameters()
        {
            OrderId = string.Empty;
            BindingId = string.Empty;
            Language = null;
            Ip = string.Empty;

            Cvc = null;
            Email = string.Empty;
        }

        public PaymentOrderBindingParameters(string orderId, string bindingId, string ip) : this()
        {
            OrderId = orderId;
            BindingId = bindingId;
            Ip = ip;
        }
        
        Dictionary<string, object> IParameters.CollectParameters()
        {
            var result = new Dictionary<string, object>
            {
                { Keys.OrderId, OrderId },
                { Keys.BindingId, BindingId }
            };
            result.AddNotNull(Keys.Language, Language);

            result.Add(Keys.Ip, Ip);

            result.AddNotNull(Keys.Cvc, Cvc);
            result.AddNotNull(Keys.Email, Email);

            return result;
        }
    }
}
