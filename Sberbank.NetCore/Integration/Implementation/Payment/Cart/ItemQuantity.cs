using Sberbank.NetCore.Integration.Interfaces;
using System.Collections.Generic;

namespace Sberbank.NetCore.Integration.Implementation.Payment.Cart
{
    public class ItemQuantity : IParameters
    {
        public ItemQuantity() : this(0d, string.Empty) { }

        public ItemQuantity(double value, string measure)
        {
            Value = value;
            Measure = measure;
        }

        public double Value { get; set; }
        public string Measure { get; set; }

        #region Implementation of IParameters

        public Dictionary<string, object> CollectParameters()
        {
            var result = new Dictionary<string, object>
            {
                { Keys.Value, Value },
                { Keys.Measure, Measure }
            };

            return result;
        }

        #endregion

        private static class Keys
        {
            public static readonly string Value = "value";
            public static readonly string Measure = "measure";
        }
    }
}
