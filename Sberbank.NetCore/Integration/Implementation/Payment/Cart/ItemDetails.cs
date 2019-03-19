using Sberbank.NetCore.Integration.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Sberbank.NetCore.Integration.Implementation.Payment.Cart
{
    public class ItemDetails : IParameters
    {
        public ItemDetails() => Parameters = new List<ItemDetailsParam>();

        public ItemDetails(IEnumerable<ItemDetailsParam> parameters) : this() => Parameters.AddRange(parameters);

        public List<ItemDetailsParam> Parameters { get; set; }

        public void Add(string name, string value) => Add(new ItemDetailsParam(name, value));

        public void Add(ItemDetailsParam parameter) => Parameters.Add(parameter);

        #region Implementation of IParameters

        public Dictionary<string, object> CollectParameters()
        {
            var result = new Dictionary<string, object>();

            var parameters = Parameters.Select(p => p.CollectParameters());
            result.Add(Keys.Parameters, parameters);

            return result;
        }

        #endregion

        private static class Keys
        {
            public static readonly string Parameters = "itemDetailsParams";
        }
    }
}
