using Sberbank.NetCore.Integration.Interfaces;
using Sberbank.NetCore.Tools;
using System;
using System.Collections.Generic;

namespace Sberbank.NetCore.Integration.Implementation.Payment.Cart
{
    public class Item : IParameters
    {
        public Item()
        {
            PositionId = 0;
            Code = Guid.NewGuid().ToString();
            Name = Guid.NewGuid().ToString();
            Details = null;
            Quantity = new ItemQuantity(1, "pcs");
            Currency = null;

            Price = Price.Zero;
            Amount = Price.Zero;
            Discount = null;
            Tax = new ItemTax();
            AgentCommission = null;
        }

        public long PositionId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }

        public ItemDetails Details { get; set; }
        public ItemQuantity Quantity { get; set; }

        public Currency? Currency { get; set; }

        public Price Price { get; set; }
        public Price Amount { get; set; }

        public ItemDiscount Discount { get; set; }
        public ItemTax Tax { get; set; }

        public AgentInterest AgentCommission { get; set; }

        #region Implementation of IParameters

        public Dictionary<string, object> CollectParameters()
        {
            var result = new Dictionary<string, object>
            {
                { Keys.PositionId, $"{PositionId}" },
                { Keys.Code, Code },
                { Keys.Name, Name },
                { Keys.Quantity, Quantity.CollectParameters() },
                { Keys.Price, Price.MinorFormat },
                { Keys.Amount, Amount.MinorFormat },
                { Keys.Tax, Tax.CollectParameters() }
            };

            result.AddNotNull(Keys.Currency, Currency);
            result.AddNotNull(Keys.Details, Details);
            result.AddNotNull(Keys.Discount, Discount);
            result.AddNotNull(Keys.AgentCommission, AgentCommission);

            return result;
        }

        #endregion

        private static class Keys
        {
            public static readonly string PositionId = "positionId";
            public static readonly string Code = "itemCode";
            public static readonly string Name = "name";
            public static readonly string Details = "itemDetails";
            public static readonly string Quantity = "quantity";
            public static readonly string Currency = "itemCurrency";
            public static readonly string Price = "itemPrice";
            public static readonly string Amount = "itemAmount";
            public static readonly string Discount = "discount";
            public static readonly string Tax = "tax";
            public static readonly string AgentCommission = "agentInterest";
        }
    }
}
