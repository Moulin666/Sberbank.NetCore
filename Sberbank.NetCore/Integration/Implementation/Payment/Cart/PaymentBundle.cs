using Sberbank.NetCore.Integration.Interfaces;
using System;
using System.Collections.Generic;

namespace Sberbank.NetCore.Integration.Implementation.Payment.Cart
{
    public class PaymentBundle : IParameters
    {
        public PaymentBundle() : this(new Item[0]) { }

        public PaymentBundle(IEnumerable<Item> items)
        {
            CreatedAt = null;
            Details = null;
            Items = new CartItems(items);
        }

        public DateTime? CreatedAt { get; set; }
        public CustomerDetails Details { get; set; }
        public CartItems Items { get; set; }

        #region Implementation of IParameters

        public Dictionary<string, object> CollectParameters()
        {
            var result = new Dictionary<string, object>();

            result.AddNotNull(Keys.CreatedAt, CreatedAt?.ToString("yyyy-MM-ddTHH:mm:ss"));
            result.AddNotNull(Keys.Details, Details);
            result.AddNotNull(Keys.Items, Items);

            return result;
        }

        #endregion

        private static class Keys
        {
            public static readonly string CreatedAt = "orderCreationDate";
            public static readonly string Details = "customerDetails";
            public static readonly string Items = "cartItems";
        }
    }
}
