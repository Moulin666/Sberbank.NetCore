using Sberbank.NetCore.Integration.Interfaces;

namespace Sberbank.NetCore.Integration.Implementation.Payment
{
    public sealed class RegisterPaymentPageView : IValueParameter
    {
        public static readonly RegisterPaymentPageView Desktop = new RegisterPaymentPageView("DESKTOP");
        public static readonly RegisterPaymentPageView Mobile = new RegisterPaymentPageView("MOBILE");

        public RegisterPaymentPageView(string value) => Value = value;

        public string Value { get; private set; }
    }
}
