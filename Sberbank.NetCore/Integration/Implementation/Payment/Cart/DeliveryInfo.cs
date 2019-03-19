using Sberbank.NetCore.Integration.Interfaces;
using System.Collections.Generic;

namespace Sberbank.NetCore.Integration.Implementation.Payment.Cart
{
    public class DeliveryInfo : IParameters
    {
        public DeliveryInfo() : this(string.Empty, string.Empty, string.Empty, string.Empty) { }

        public DeliveryInfo(string type, string country, string city, string address)
        {
            Type = type;
            Country = country;
            City = city;
            Address = address;
        }

        public string Type { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Address { get; set; }

        #region Implementation of IParameters

        public Dictionary<string, object> CollectParameters()
        {
            var result = new Dictionary<string, object>();

            result.AddNotNull(Keys.Type, Type);
            result.Add(Keys.Country, Country);
            result.Add(Keys.City, City);
            result.Add(Keys.Address, Address);

            return result;
        }

        #endregion

        private static class Keys
        {
            public static readonly string Type = "deliveryType";
            public static readonly string Country = "country";
            public static readonly string City = "city";
            public static readonly string Address = "postAddress";
        }
    }
}
