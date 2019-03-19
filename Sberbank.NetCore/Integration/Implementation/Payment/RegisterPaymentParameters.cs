using Newtonsoft.Json;
using Sberbank.NetCore.Integration.Implementation.Payment.Cart;
using Sberbank.NetCore.Integration.Interfaces;
using Sberbank.NetCore.Tools;
using System;
using System.Collections.Generic;

namespace Sberbank.NetCore.Integration.Implementation.Payment
{
    public class RegisterPaymentParameters : IParameters
    {
        public RegisterPaymentParameters()
        {
            OrderNumber = Guid.NewGuid().ToString("N");
            Amount = Price.Zero;
            Currency = null;

            ReturnUrl = string.Empty;
            FailUrl = null;

            Description = null;
            Language = null;

            PageView = null;
            ClientId = null;
            MerchantLogin = null;

            Parameters = null;

            SessionTimeoutSeconds = null;
            ExpirationDate = null;
            BindingId = null;
            Features = null;

            PaymentBundle = null;
            TaxSystem = null;
        }

        /// <summary>
        /// Register one payment.
        /// </summary>
        /// <param name="amount">Order amount</param>
        /// <param name="returnUrl">Url for return after payment</param>
        /// <param name="currency">Currency of order</param>
        public RegisterPaymentParameters(Price amount, string returnUrl, Currency? currency = null) : this()
        {
            Amount = amount;
            Currency = currency;
            ReturnUrl = returnUrl;
        }

        /// <summary>
        /// Register payment for initialize bindings or one-click payments.
        /// </summary>
        /// <param name="clientId">Client id for save card</param>
        /// <param name="amount">Amount of init order</param>
        /// <param name="returnUrl">Url for return after registration</param>
        /// <param name="currency">Currency of order</param>
        public RegisterPaymentParameters(string clientId, Price amount, string returnUrl,
            Currency? currency = null, bool mobile = false) : this()
        {
            ClientId = clientId;
            Amount = amount;
            ReturnUrl = returnUrl;
            Currency = currency;

            PageView = mobile ? RegisterPaymentPageView.Mobile : RegisterPaymentPageView.Desktop;
        }

        /// <summary>
        /// Register order for payment via one click.
        /// </summary>
        /// <param name="clientId">Client id for reuse card</param>
        /// <param name="bindingId">Binding id for reuse card's data</param>
        /// <param name="amount">Amount of order</param>
        /// <param name="currency">Currency of order</param>
        /// <param name="orderNumber">Custom order number</param>
        public RegisterPaymentParameters(string clientId, string bindingId, Price amount, Currency? currency = null,
            string orderNumber = null) : this()
        {
            ClientId = clientId;
            BindingId = bindingId;
            Amount = amount;
            Currency = currency;

            if (!string.IsNullOrEmpty(orderNumber))
                OrderNumber = orderNumber;

            ReturnUrl = "http://localhost";
            Features = RegisterPaymentFeatures.AutoPayment;
        }
        
        public string OrderNumber { get; set; }
        public Price Amount { get; set; }
        public Currency? Currency { get; set; }

        public string ReturnUrl { get; set; }
        public string FailUrl { get; set; }

        public string Description { get; set; }
        public LanguageParameter Language { get; set; }

        public RegisterPaymentPageView PageView { get; set; }
        public string ClientId { get; set; }
        public string MerchantLogin { get; set; }

        public Dictionary<string, string> Parameters { get; set; }

        public int? SessionTimeoutSeconds { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public string BindingId { get; set; }
        public RegisterPaymentFeatures Features { get; set; }
        public PaymentBundle PaymentBundle { get; set; }
        public TaxSystem? TaxSystem { get; set; }

        #region Implementation of IParameters

        Dictionary<string, object> IParameters.CollectParameters()
        {
            var result = new Dictionary<string, object>
            {
                { Keys.OrderNumber, OrderNumber },
                { Keys.Amount, $"{Amount.MinorFormat}" }
            };
            result.AddNotNull(Keys.Currency, Currency);

            result.Add(Keys.ReturnUrl, ReturnUrl);
            result.AddNotNull(Keys.FailUrl, FailUrl);

            result.AddNotNull(Keys.Description, Description);
            result.AddNotNull(Keys.Language, Language);

            result.AddNotNull(Keys.PageView, PageView);
            result.AddNotNull(Keys.ClientId, ClientId);
            result.AddNotNull(Keys.MerchantLogin, MerchantLogin);

            if (Parameters != null)
                result.AddNotNull(Keys.Parameters, JsonConvert.SerializeObject(Parameters));

            result.AddNotNull(Keys.SessionTimeoutSeconds, SessionTimeoutSeconds?.ToString());
            result.AddNotNull(Keys.ExpirationDate, ExpirationDate.ToString());
            result.AddNotNull(Keys.BindingId, BindingId);
            result.AddNotNull(Keys.Features, Features);

            result.AddNotNull(Keys.OrderBundle, PaymentBundle);
            result.AddNotNull(Keys.TaxSystem, TaxSystem);

            return result;
        }

        #endregion

        public static class Keys
        {
            public static readonly string OrderNumber = "orderNumber";
            public static readonly string Amount = "amount";
            public static readonly string Currency = "currency";

            public static readonly string ReturnUrl = "returnUrl";
            public static readonly string FailUrl = "failUrl";

            public static readonly string Description = "description";
            public static readonly string Language = "language";

            public static readonly string PageView = "pageView";
            public static readonly string ClientId = "clientId";
            public static readonly string MerchantLogin = "merchantLogin";

            public static readonly string Parameters = "jsonParams";

            public static readonly string SessionTimeoutSeconds = "sessionTimeoutSecs";
            public static readonly string ExpirationDate = "expirationDate";
            public static readonly string BindingId = "bindingId";
            public static readonly string Features = "features";

            public static readonly string OrderBundle = "orderBundle";
            public static readonly string TaxSystem = "taxSystem";
        }
    }
}
