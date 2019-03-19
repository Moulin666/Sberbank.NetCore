using Sberbank.NetCore.Integration.Interfaces;
using System.Collections.Generic;

namespace Sberbank.NetCore.Integration.Implementation
{
    public class ReverseParameters : IParameters
    {
        public static class Keys
        {
            public static readonly string OrderId = "orderId";
            public static readonly string Language = "language";
        }

        public string OrderId { get; set; }

        public LanguageParameter Language { get; set; }

        public ReverseParameters() : this(string.Empty) { }

        public ReverseParameters(string orderId, LanguageParameter language = null)
        {
            OrderId = orderId;
            Language = language;
        }

        Dictionary<string, object> IParameters.CollectParameters()
        {
            var result = new Dictionary<string, object>
            {
                { Keys.OrderId, OrderId }
            };
            result.AddNotNull(Keys.Language, Language);

            return result;
        }
    }
}
