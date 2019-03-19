using Sberbank.NetCore.Integration.Interfaces;
using System.Collections.Generic;

namespace Sberbank.NetCore.Integration.Implementation.Payment.Cart
{
    public class CustomerDetails : IParameters
    {
        public CustomerDetails() : this(string.Empty, string.Empty, string.Empty) { }

        public CustomerDetails(string email, string phone, string contact)
        {
            Email = email;
            Phone = phone;
            Contact = contact;
            Delivery = null;
        }

        public string Email { get; set; }
        public string Phone { get; set; }
        public string Contact { get; set; }

        public DeliveryInfo Delivery { get; set; }

        #region Implementation of IParameters

        public Dictionary<string, object> CollectParameters()
        {
            var result = new Dictionary<string, object>();

            result.AddNotNull(Keys.Email, Email);
            result.AddNotNull(Keys.Phone, Phone);
            result.AddNotNull(Keys.Contact, Contact);
            result.AddNotNull(Keys.Delivery, Delivery);

            return result;
        }

        #endregion

        private static class Keys
        {
            public static readonly string Email = "email";
            public static readonly string Phone = "phone";
            public static readonly string Contact = "contact";
            public static readonly string Delivery = "deliveryInfo";
        }
    }
}
