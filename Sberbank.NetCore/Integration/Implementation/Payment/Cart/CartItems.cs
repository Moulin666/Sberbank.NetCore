using Sberbank.NetCore.Integration.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Sberbank.NetCore.Integration.Implementation.Payment.Cart
{
    public class CartItems : IParameters
    {
        public CartItems() => Items = new List<Item>();

        public CartItems(IEnumerable<Item> items) : this() => Items.AddRange(items);

        public List<Item> Items { get; set; }

        public void Add(Item item) => Items.Add(item);

        #region Implementation of IParameters

        public Dictionary<string, object> CollectParameters()
        {
            var result = new Dictionary<string, object>();

            var parameters = Items.Select(p => p.CollectParameters());
            result.Add(Keys.Items, parameters);

            return result;
        }

        #endregion

        private static class Keys
        {
            public static readonly string Items = "items";
        }
    }
}
