using Sberbank.NetCore.Integration.Interfaces;
using System.Collections.Generic;

namespace Sberbank.NetCore.Integration.Implementation.Payment.Cart
{
    public class ItemDetailsParam : IParameters
    {
        public ItemDetailsParam() : this(string.Empty, string.Empty) { }

        public ItemDetailsParam(string name, string value)
        {
            Name = name;
            Value = value;
        }

        public string Name { get; set; }
        public string Value { get; set; }

        #region Implementation of IParameters

        public Dictionary<string, object> CollectParameters()
        {
            var result = new Dictionary<string, object>
            {
                { Keys.Name, Name },
                { Keys.Value, Value }
            };

            return result;
        }

        #endregion

        private static class Keys
        {
            public static readonly string Name = "name";
            public static readonly string Value = "value";
        }
    }
}
