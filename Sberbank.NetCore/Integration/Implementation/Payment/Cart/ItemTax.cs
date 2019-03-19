using Sberbank.NetCore.Integration.Interfaces;
using Sberbank.NetCore.Tools;
using System.Collections.Generic;

namespace Sberbank.NetCore.Integration.Implementation.Payment.Cart
{
    public class ItemTax : IParameters
    {
        public ItemTax() : this(ItemTaxType.WithoutVat, 0d) { }

        public ItemTax(ItemTaxType type, double sum = 0d)
        {
            Type = type;
            Sum = new Price(sum);
        }

        public ItemTaxType Type { get; set; }
        public Price Sum { get; set; }

        #region Implementation of IParameters

        public Dictionary<string, object> CollectParameters()
        {
            var result = new Dictionary<string, object>
            {
                { Keys.TaxType, (int)Type },
                { Keys.Sum, Sum.MinorFormat }
            };

            return result;
        }

        #endregion

        private static class Keys
        {
            public static readonly string TaxType = "taxType";
            public static readonly string Sum = "taxSum";
        }
    }
}
